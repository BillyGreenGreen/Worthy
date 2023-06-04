using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    private void Update() {
        foreach (Potion potion in GameManager.instance.GM_hotbar_potions.Values){
            if (Input.GetKeyDown(potion.keyBind) && !potion.potionIsBeingUsed){
                Debug.Log(potion._name);
                potion.potionIsBeingUsed = true;
                potion.ActivatePotion();
            }
            else if (potion.potionIsBeingUsed){
                potion.timeRemaining -= Time.deltaTime;
                if (potion.timeRemaining <= 0f){
                    potion.RemovePotion();
                }
            }
        }
    }
}