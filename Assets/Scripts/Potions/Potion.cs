using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion
{
    public string _name;
    public Sprite icon;
    public float timeRemaining;
    public KeyCode keyBind;

    public bool potionIsBeingUsed = false;
    
    public Potion(string name, KeyCode hotkey = KeyCode.None){
        _name = name;
        keyBind = hotkey;
        icon = Resources.Load<Sprite>("Potions/" + name);
        switch (_name){
            case("Potion of Power"):
                timeRemaining = 30;
                break;
            case("Potent Potion of Power"):
                //icon = icon that we make in resources
                timeRemaining = 20;
                break;
            case("Worthy Potion of Power"):
                //icon = icon that we make in resources
                timeRemaining = 15;
                break;
            case("Potion of Speed"):
                //icon = icon that we make in resources
                timeRemaining = 25;
                break;
            case("Potent Potion of Speed"):
                //icon = icon that we make in resources
                timeRemaining = 20;
                break;
            case("Worthy Potion of Speed"):
                //icon = icon that we make in resources
                timeRemaining = 15;
                break;
            case("Potion of Evasion"):
                //icon = icon that we make in resources
                timeRemaining = 15;
                break;
            case("Potent Potion of Evasion"):
                //icon = icon that we make in resources
                timeRemaining = 12;
                break;
            case("Worthy Potion of Evasion"):
                //icon = icon that we make in resources
                timeRemaining = 10;
                break;
        }
    }

    public void ActivatePotion(){
        float speed = GameObject.Find("Player").GetComponent<PlayerMovement>().speed;
        float multiplier = 0f;

        float speedNormalPercent = 15f;
        float speedPotentPercent = 30f;
        float speedWorthyPercent = 60f;

        float evasionNormalPercent = 10f;
        float evasionPotentPercent = 25f;
        float evasionWorthyPercent = 50f;
        switch (_name){
            case("Potion of Power"):
                //add the buff here
                GameManager.instance.powerPotionLevel = "Medium";
                break;
            case("Potent Potion of Power"):
                GameManager.instance.powerPotionLevel = "High";
                break;
            case("Worthy Potion of Power"):
                GameManager.instance.powerPotionLevel = "Worthy";
                break;
            case("Potion of Speed"):
                multiplier = (speedNormalPercent / 100f) * speed;
                GameObject.Find("Player").GetComponent<PlayerMovement>().speed += multiplier;
                break;
            case("Potent Potion of Speed"):
                multiplier = (speedPotentPercent / 100f) * speed;
                GameObject.Find("Player").GetComponent<PlayerMovement>().speed += multiplier;
                break;
            case("Worthy Potion of Speed"):
                multiplier = (speedWorthyPercent / 100f) * speed;
                GameObject.Find("Player").GetComponent<PlayerMovement>().speed += multiplier;
                break;
            case("Potion of Evasion"):
                GameObject.Find("Player").GetComponent<Player>().dodgeChance = evasionNormalPercent;
                break;
            case("Potent Potion of Evasion"):
                GameObject.Find("Player").GetComponent<Player>().dodgeChance = evasionPotentPercent;
                break;
            case("Worthy Potion of Evasion"):
                GameObject.Find("Player").GetComponent<Player>().dodgeChance = evasionWorthyPercent;
                break;
        }
    }

    public void RemovePotion(){
        switch (_name){
            case("Potion of Power"):
                timeRemaining = 30;
                potionIsBeingUsed = false;
                GameManager.instance.powerPotionLevel = "None";
                break;
            case("Potent Potion of Power"):
                timeRemaining = 20;
                potionIsBeingUsed = false;
                GameManager.instance.powerPotionLevel = "None";
                break;
            case("Worthy Potion of Power"):
                timeRemaining = 15;
                potionIsBeingUsed = false;
                GameManager.instance.powerPotionLevel = "None";
                break;
            case("Potion of Speed"):
                timeRemaining = 25;
                potionIsBeingUsed = false;
                GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 5f;
                break;
            case("Potent Potion of Speed"):
                timeRemaining = 20;
                potionIsBeingUsed = false;
                GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 5f;
                break;
            case("Worthy Potion of Speed"):
                timeRemaining = 15;
                potionIsBeingUsed = false;
                GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 5f;
                break;
            case("Potion of Evasion"):
                timeRemaining = 15;
                potionIsBeingUsed = false;
                GameObject.Find("Player").GetComponent<Player>().dodgeChance = 0f;
                break;
            case("Potent Potion of Evasion"):
                timeRemaining = 12;
                potionIsBeingUsed = false;
                GameObject.Find("Player").GetComponent<Player>().dodgeChance = 0f;
                break;
            case("Worthy Potion of Evasion"):
                timeRemaining = 10;
                potionIsBeingUsed = false;
                GameObject.Find("Player").GetComponent<Player>().dodgeChance = 0f;
                break;
        }
    }
}
