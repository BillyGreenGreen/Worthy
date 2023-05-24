using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    public Dictionary<int, Ability> GM_abilities = new Dictionary<int, Ability>();
    public List<Ability> GM_usable_abilities = new List<Ability>();//THIS IS USED ONLY FOR TESTING

    public List<Ability> GM_buyable_abilities = new List<Ability>();
    public List<Ability> GM_bought_abilities = new List<Ability>();
    public Dictionary<int, Ability> GM_hotbar_abilities = new Dictionary<int, Ability>();

    public Dictionary<GameObject, float> GM_DurationAbilities = new Dictionary<GameObject, float>();
    public TextMeshProUGUI debug;
    public bool canDropAbilityInInventory;
    public bool upgradeMenuOpen;

    //Player Stats
    public string GM_class_selected;

    public int GM_currency;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start(){
        GM_class_selected = "Elementalist";//TESTING ONLY

        if (!PlayerPrefs.HasKey("Currency")){
            //PlayerPrefs.SetInt("Currency", 0);
            //GM_currency = 0;
        }
        else{
            //GM_currency = PlayerPrefs.GetInt("Currency");
        }

        //abilities added for testing, will have switch case to add all usable abilities here.
        //these will be used and updated when using the shop feature

        /*
        GM_usable_abilities.Add(new Ability("Mage_FlamePool", KeyCode.None));
        GM_usable_abilities.Add(new Ability("Mage_IceSpike", KeyCode.None));
        GM_usable_abilities.Add(new Ability("Mage_ChainShock", KeyCode.None));
        GM_usable_abilities.Add(new Ability("Mage_EarthWarden", KeyCode.None));
        GM_usable_abilities.Add(new Ability("Mage_FlowingWater", KeyCode.None));
        GM_usable_abilities.Add(new Ability("Mage_FrozenOrb", KeyCode.None));
        GM_usable_abilities.Add(new Ability("Mage_WhistlingShield", KeyCode.None));

        GM_abilities.Add(1, new Ability("Mage_FlamePool", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability1"))));
        GM_abilities.Add(2, new Ability("Mage_IceSpike", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability2"))));
        GM_abilities.Add(3, new Ability("NoAbility", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability3"))));
        GM_abilities.Add(4, new Ability("NoAbility", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability4"))));*/

        string abilitiesFormatted = "";

        for (int i = 1; i <= GM_abilities.Count; i++)
        {
            abilitiesFormatted += GM_abilities[i].hotkey + "\n";
        }
        //debug.text = "Ability Debug:\n" + abilitiesFormatted;



    }

    void Update()
    {
        foreach (Ability ability in GM_hotbar_abilities.Values)
        {
            if (!ability.ready)
            {
                ability.cooldownTimer -= Time.deltaTime;

                if (ability.cooldownTimer <= 0f)
                {
                    ability.ready = true;
                    ability.cooldownTimer = ability.cooldownTime;
                }

            }

            if (ability.ready && Input.GetKeyDown(ability.hotkey))
            {
                ActivateAbility(ability);
                foreach (Ability ab in GM_abilities.Values){
                    if (ab.name == ability.name){
                        PutOnCooldown(ab);
                    }
                }
                
            }
        }

        List<GameObject> gameObjectsToClear = new List<GameObject>();
        List<GameObject> keys = new List<GameObject>(GM_DurationAbilities.Keys);
        foreach (GameObject prefab in keys){
            GM_DurationAbilities[prefab] -= Time.deltaTime;
            //Debug.Log("Object:" + prefab.name + " Timer: " + timer);
            if (GM_DurationAbilities[prefab] <= 0){
                Destroy(prefab);
                gameObjectsToClear.Add(prefab);
            }
        }
        foreach (GameObject go in gameObjectsToClear){
            GM_DurationAbilities.Remove(go);
        }

        
    }

    public void LoadClassAbilities(){
        //validation on whether or not its first time playing is needed here
        switch(GM_class_selected){
            case "Elementalist":
                GM_buyable_abilities.Add(new Ability("Mage_IceSpike", KeyCode.None));
                GM_buyable_abilities.Add(new Ability("Mage_ChainShock", KeyCode.None));
                GM_buyable_abilities.Add(new Ability("Mage_EarthWarden", KeyCode.None));
                GM_buyable_abilities.Add(new Ability("Mage_FlowingWater", KeyCode.None));
                GM_buyable_abilities.Add(new Ability("Mage_FrozenOrb", KeyCode.None));
                GM_buyable_abilities.Add(new Ability("Mage_WhistlingShield", KeyCode.None));

                GM_bought_abilities.Add(new Ability("Mage_FlamePool", KeyCode.None));

                GM_hotbar_abilities.Add(1, new Ability("Mage_FlamePool", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability1"))));
                GM_hotbar_abilities.Add(2, new Ability("NoAbility", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability2"))));
                GM_hotbar_abilities.Add(3, new Ability("NoAbility", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability3"))));
                GM_hotbar_abilities.Add(4, new Ability("NoAbility", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability4"))));
                break;
        }
    }

    void ActivateAbility(Ability ability)
    {
        ability.ready = false;
        ability.cooldownTimer = ability.cooldownTime;
        Debug.Log("Activated " + ability.name);
        
        if (ability.name.Contains("Mage")){
            Mage.ActivateAbility(ability.name);
        }
    }

    void PutOnCooldown(Ability ability){
        ability.ready = false;
        ability.cooldownTimer = ability.cooldownTime;
    }

    //For duration abilities
    public void AddDurationAbility(GameObject prefab, float time){
        GM_DurationAbilities.Add(prefab, time);
    }
}
