using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Ability
{
    public string name;
    public KeyCode hotkey;
    public float cooldownTime;
    public float cooldownTimer;
    public int charges;
    public Sprite icon;
    public int baseCost;
    public bool ready = true;
    
    //implement all above
    public Ability(string name, KeyCode hotkey)
    {
        this.name = name;
        this.hotkey = hotkey;
        UpdateAbility();
    }


    public void UpdateAbility(){
        //use to update icons when ability is changed on hotbar
        switch(this.name){
            //Mage
            case "Mage_FlamePool":
                icon = Resources.Load<Sprite>("Abilities/Mage_FlamePool_500px");
                cooldownTime = 10f;
                baseCost = 200;
                break;
            case "Mage_IceSpike":
                icon = Resources.Load<Sprite>("Abilities/Mage_IceSpike_500px");
                cooldownTime = 3f;
                baseCost = 100;
                break;

            case "Mage_ChainShock":
                icon = Resources.Load<Sprite>("Abilities/Mage_ChainShock_500px");
                cooldownTime = 5f;
                baseCost = 300;
                break;
            case "Mage_EarthWarden":
                icon = Resources.Load<Sprite>("Abilities/Mage_EarthWarden_500px");
                cooldownTime = 30f;
                baseCost = 500;
                break;
            case "Mage_FlowingWater":
                icon = Resources.Load<Sprite>("Abilities/Mage_FlowingWater_500px");
                cooldownTime = 12f;
                baseCost = 100;
                break;
            case "Mage_FrozenOrb":
                icon = Resources.Load<Sprite>("Abilities/Mage_FrozenOrb_500px");
                cooldownTime = 8f;
                baseCost = 200;
                break;
            case "Mage_WhistlingShield":
                icon = Resources.Load<Sprite>("Abilities/Mage_WhistlingShield_500px");
                cooldownTime = 15f;
                baseCost = 150;
                break;


            //NoAbility
            case "NoAbility":
                icon = Resources.Load<Sprite>("Abilities/circle");
                cooldownTime = -1f;
                break;
            default:
                icon = Resources.Load<Sprite>("Abilities/circle");
                cooldownTime = -1f;
                break;
        }
    }
}
