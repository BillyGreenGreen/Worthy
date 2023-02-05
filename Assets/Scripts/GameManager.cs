using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<string> GM_abilities = new List<string>();
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

    public void addAbility(string abilityName)
    {
        //this will be where we change the certain ability when we implement it
        GM_abilities.Add(abilityName);
        string abilitiesFormatted = "";

        for (int i = 0; i < GM_abilities.Count; i++)
        {
            abilitiesFormatted += GM_abilities[i] + "\n";
        }
        debug.text = "Ability Debug:\n" + abilitiesFormatted;
    }
}
