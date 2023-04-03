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
    public TextMeshProUGUI debug;

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
            }
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
