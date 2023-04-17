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
    public int charges;
    public Sprite icon;
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
                icon = Resources.Load<Sprite>("Abilities/FlamePool_500px");
                cooldownTime = 10f;
                break;
            case "Mage_IceSpike":
                icon = Resources.Load<Sprite>("Abilities/IceSpike_500px");
                cooldownTime = 3f;
                break;

            case "Mage_ChainShock":
                icon = Resources.Load<Sprite>("Abilities/ChainShock_500px");
                cooldownTime = 5f;
                break;
            case "Mage_EarthWarden":
                icon = Resources.Load<Sprite>("Abilities/EarthWarden_500px");
                cooldownTime = 30f;
                break;
            case "Mage_FlowingWater":
                icon = Resources.Load<Sprite>("Abilities/FlowingWater_500px");
                cooldownTime = 12f;
                break;
            case "Mage_FrozenOrb":
                icon = Resources.Load<Sprite>("Abilities/FrozenOrb_500px");
                cooldownTime = 8f;
                break;
            case "Mage_WhistlingShield":
                icon = Resources.Load<Sprite>("Abilities/WhistlingShield_500px");
                cooldownTime = 15f;
                break;


            //NoAbility
            case "NoAbility":
                icon = Resources.Load<Sprite>("Abilities/Circle");
                cooldownTime = -1f;
                break;
            default:
                icon = Resources.Load<Sprite>("Abilities/Circle");
                cooldownTime = -1f;
                break;
        }
    }
}
