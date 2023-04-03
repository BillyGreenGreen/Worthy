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
    public bool ready = true;
    
    //implement all above
    public Ability(string name, KeyCode hotkey, float cooldownTime)
    {
        this.name = name;
        this.hotkey = hotkey;
        this.cooldownTime = cooldownTime;

        switch(name){
            case "Mage_FlamePool":
                icon = Resources.Load<Sprite>("Abilities/FlamePool_500px");

                break;
            case "Mage_IceSpike":
                icon = Resources.Load<Sprite>("Abilities/IceSpike_500px");
                break;
            default:
                icon = Resources.Load<Sprite>("Abilities/FlamePool_500px");
                break;
        }
    }
}
