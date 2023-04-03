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
    public Image icon;
    public bool ready = true;
    
    //implement all above
    public Ability(string name, KeyCode hotkey, float cooldownTime, Image icon)
    {
        this.name = name;
        this.hotkey = hotkey;
        this.cooldownTime = cooldownTime;
        this.icon = icon;
    }
}
