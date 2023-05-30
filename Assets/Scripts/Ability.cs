using System;
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
    public string description;
    public bool ready = true;
    public Vector2Int morphLevel;
    
    //implement all above

    /*colour codes
    frost [#43aee8]
    flame [#eb6134]
    wind [#dcf1fc]
    lightning [#f7dc0f]

    light [#43e86c]
    medium [#3449eb]
    high [#e84346]


    */
    public Ability(string name, KeyCode hotkey = KeyCode.None)
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
                description = "<color=#FFFFFF>Conjure a pool of flames at a target location, dealing <color=#3449eb>medium <color=#FFFFFF>damage over time and applying a <color=#eb6134>Flame <color=#FFFFFF>debuff.";
                cooldownTime = 10f;
                baseCost = 200;
                morphLevel = new Vector2Int(0,0);
                /*if (PlayerPrefs.HasKey(this.name + "_MorphLevel")){
                    string[] morphLevelString = PlayerPrefs.GetString(this.name + "_MorphLevel").Split(",");
                    morphLevel = new Vector2Int(Convert.ToInt32(morphLevelString[0]),Convert.ToInt32(morphLevelString[1]));
                }
                else{
                    morphLevel = new Vector2Int(0,0);
                }*/
                
                break;
            case "Mage_IceSpike":
                icon = Resources.Load<Sprite>("Abilities/Mage_IceSpike_500px");
                description = "<color=#FFFFFF>Manifest a harmful spike of compressed ice and hurl it forwards. Will deal <color=#e84346>high <color=#FFFFFF>damage to the target.";
                cooldownTime = 3f;
                baseCost = 100;
                morphLevel = new Vector2Int(0,0);
                /*if (PlayerPrefs.HasKey(this.name + "_MorphLevel")){
                    string[] morphLevelString = PlayerPrefs.GetString(this.name + "_MorphLevel").Split(",");
                    morphLevel = new Vector2Int(Convert.ToInt32(morphLevelString[0]),Convert.ToInt32(morphLevelString[1]));
                }
                else{
                    morphLevel = new Vector2Int(0,0);
                }*/
                break;

            case "Mage_ChainShock":
                icon = Resources.Load<Sprite>("Abilities/Mage_ChainShock_500px");
                description = "<color=#FFFFFF>Produce static ball of <color=#f7dc0f>lightning <color=#FFFFFF>and discharge it forwards.\nDeal <color=#43e86c>light <color=#FFFFFF>damage and when an enemy is hit the damage dealt will also chain to 3 targets around the enemy.";
                cooldownTime = 5f;
                baseCost = 300;
                morphLevel = new Vector2Int(0,0);
                /*if (PlayerPrefs.HasKey(this.name + "_MorphLevel")){
                    string[] morphLevelString = PlayerPrefs.GetString(this.name + "_MorphLevel").Split(",");
                    morphLevel = new Vector2Int(Convert.ToInt32(morphLevelString[0]),Convert.ToInt32(morphLevelString[1]));
                }
                else{
                    morphLevel = new Vector2Int(0,0);
                }*/
                break;
            case "Mage_EarthWarden":
                icon = Resources.Load<Sprite>("Abilities/Mage_EarthWarden_500px");
                description = "<color=#FFFFFF>Summon an Earth Warden totem at the target location. The totem will taunt any enemies that are near and will take damage until its health is 0.";
                cooldownTime = 30f;
                baseCost = 500;
                morphLevel = new Vector2Int(0,0);
                /*if (PlayerPrefs.HasKey(this.name + "_MorphLevel")){
                    string[] morphLevelString = PlayerPrefs.GetString(this.name + "_MorphLevel").Split(",");
                    morphLevel = new Vector2Int(Convert.ToInt32(morphLevelString[0]),Convert.ToInt32(morphLevelString[1]));
                }
                else{
                    morphLevel = new Vector2Int(0,0);
                }*/
                break;
            case "Mage_FlowingWater":
                icon = Resources.Load<Sprite>("Abilities/Mage_FlowingWater_500px");
                description = "<color=#FFFFFF>Apply a heal over time effect to yourself, healing for <color=#43e86c>light <color=#FFFFFF>amounts 5 times over 10 seconds";
                cooldownTime = 12f;
                baseCost = 100;
                morphLevel = new Vector2Int(0,0);
                /*if (PlayerPrefs.HasKey(this.name + "_MorphLevel")){
                    string[] morphLevelString = PlayerPrefs.GetString(this.name + "_MorphLevel").Split(",");
                    morphLevel = new Vector2Int(Convert.ToInt32(morphLevelString[0]),Convert.ToInt32(morphLevelString[1]));
                }
                else{
                    morphLevel = new Vector2Int(0,0);
                }*/
                break;
            case "Mage_FrozenOrb":
                icon = Resources.Load<Sprite>("Abilities/Mage_FrozenOrb_500px");
                description = "<color=#FFFFFF>Launch a ball of swirling ice at a target location which will deal <color=#43e86c>light <color=#FFFFFF>damage over time to nearby enemies and give them a <color=#43aee8>Frost <color=#FFFFFF>debuff.";
                cooldownTime = 8f;
                baseCost = 200;
                morphLevel = new Vector2Int(0,0);
                /*if (PlayerPrefs.HasKey(this.name + "_MorphLevel")){
                    string[] morphLevelString = PlayerPrefs.GetString(this.name + "_MorphLevel").Split(",");
                    morphLevel = new Vector2Int(Convert.ToInt32(morphLevelString[0]),Convert.ToInt32(morphLevelString[1]));
                }
                else{
                    morphLevel = new Vector2Int(0,0);
                }*/
                break;
            case "Mage_WhistlingShield":
                icon = Resources.Load<Sprite>("Abilities/Mage_WhistlingShield_500px");
                description = "<color=#FFFFFF>Construct a shield made from whistling winds which provides a 75 health shield and does <color=#43e86c>light <color=#dcf1fc>Wind <color=#FFFFFF>damage to nearby enemies.";
                cooldownTime = 15f;
                baseCost = 150;
                morphLevel = new Vector2Int(0,0);
                /*if (PlayerPrefs.HasKey(this.name + "_MorphLevel")){
                    string[] morphLevelString = PlayerPrefs.GetString(this.name + "_MorphLevel").Split(",");
                    morphLevel = new Vector2Int(Convert.ToInt32(morphLevelString[0]),Convert.ToInt32(morphLevelString[1]));
                }
                else{
                    morphLevel = new Vector2Int(0,0);
                }*/
                break;


            //NoAbility
            case "NoAbility":
                icon = Resources.Load<Sprite>("Abilities/circle");
                cooldownTime = -1f;
                morphLevel = new Vector2Int(0,0);
                /*if (PlayerPrefs.HasKey(this.name + "_MorphLevel")){
                    string[] morphLevelString = PlayerPrefs.GetString(this.name + "_MorphLevel").Split(",");
                    morphLevel = new Vector2Int(Convert.ToInt32(morphLevelString[0]),Convert.ToInt32(morphLevelString[1]));
                }
                else{
                    morphLevel = new Vector2Int(0,0);
                }*/
                break;
            default:
                icon = Resources.Load<Sprite>("Abilities/circle");
                cooldownTime = -1f;
                morphLevel = new Vector2Int(0,0);
                /*if (PlayerPrefs.HasKey(this.name + "_MorphLevel")){
                    string[] morphLevelString = PlayerPrefs.GetString(this.name + "_MorphLevel").Split(",");
                    morphLevel = new Vector2Int(Convert.ToInt32(morphLevelString[0]),Convert.ToInt32(morphLevelString[1]));
                }
                else{
                    morphLevel = new Vector2Int(0,0);
                }*/
                break;
        }
    }
}
