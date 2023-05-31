using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion
{
    string _name;
    int timeRemaining;
    Image icon;
    public Potion(string name){
        _name = name;

        switch (_name){
            case("Potion of Power"):
                //icon = icon that we make in resources
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
}
