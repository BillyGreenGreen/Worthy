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
    public List<Ability> GM_usable_abilities = new List<Ability>();
    public Dictionary<GameObject, float> GM_AbilityTimeInScene = new Dictionary<GameObject, float>();
    public TextMeshProUGUI debug;

    //Player Stats
    public string GM_class_selected;

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

        //abilities added for testing, will have switch case to add all usable abilities here.
        //these will be used and updated when using the shop feature
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
        GM_abilities.Add(4, new Ability("NoAbility", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability4"))));

        string abilitiesFormatted = "";

        for (int i = 1; i <= GM_abilities.Count; i++)
        {
            abilitiesFormatted += GM_abilities[i].hotkey + "\n";
        }
        debug.text = "Ability Debug:\n" + abilitiesFormatted;



    }

    void Update()
    {
        foreach (Ability ability in GM_abilities.Values)
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
        List<GameObject> keys = new List<GameObject>(GM_AbilityTimeInScene.Keys);
        foreach (GameObject prefab in keys){
            GM_AbilityTimeInScene[prefab] -= Time.deltaTime;
            //Debug.Log("Object:" + prefab.name + " Timer: " + timer);
            if (GM_AbilityTimeInScene[prefab] <= 0){
                Destroy(prefab);
                gameObjectsToClear.Add(prefab);
            }
        }
        foreach (GameObject go in gameObjectsToClear){
            GM_AbilityTimeInScene.Remove(go);
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

    public void AddAbilityInSceneTimer(GameObject prefab, float time){
        GM_AbilityTimeInScene.Add(prefab, time);
    }

    public void addAbility(string abilityName)
    {
        //this will be where we change the certain ability when we implement it
        //GM_abilities.Add(abilityName);
        string abilitiesFormatted = "";

        for (int i = 0; i < GM_abilities.Count; i++)
        {
            abilitiesFormatted += GM_abilities[i] + "\n";
        }
        debug.text = "Ability Debug:\n" + abilitiesFormatted;
    }
}
