using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public string name;
    public KeyCode hotkey;
    public float cooldownTime;
    public float cooldownTimer;
    public int charges;
    public bool ready = true;
    

    public Ability(string name, KeyCode hotkey, float cooldownTime)
    {
        this.name = name;
        this.hotkey = hotkey;
        this.cooldownTime = cooldownTime;
    }
}
