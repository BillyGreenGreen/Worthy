using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    public int health = 300;
    
    public TextMeshProUGUI healthText;
    float timeColliding; //this will have to change with multiple duration abilities

    bool inFlamePool = false;

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
        if (health < 1){
            Destroy(gameObject);
        }

        /*if (inFlamePool){
            if (gameObject.GetComponent<DamageOverTime>() == null){        
                DamageOverTime DOT = gameObject.AddComponent<DamageOverTime>();
                DOT.UpdateTickInfo(3, 10, 1);
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("COLLIDE :   " + other.transform.name);
        switch(other.transform.name){
            case "Mage_FlamePool(Clone)":
                FlamePoolDOT flamePoolDOT = gameObject.AddComponent<FlamePoolDOT>();
                flamePoolDOT.UpdateDOTInfo(3, 10, 1);//ticks, damagePerTick, timeBetweenTicks
                break;
            case "Mage_FrozenOrb(Clone)":
                FrozenOrbDOT frozenOrbDOT = gameObject.AddComponent<FrozenOrbDOT>();
                frozenOrbDOT.UpdateDOTInfo(10, 2, 0.2f);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        switch(other.transform.name){
            
            case "Mage_FlamePool(Clone)":
                if (gameObject.GetComponent<FlamePoolDOT>() == null){
                    FlamePoolDOT flamePoolDOT = gameObject.AddComponent<FlamePoolDOT>();
                    flamePoolDOT.UpdateDOTInfo(3, 10, 1);
                }
                break;
            case "Mage_FrozenOrb(Clone)":
                if (gameObject.GetComponent<FrozenOrbDOT>() == null){
                    FrozenOrbDOT frozenOrbDOT = gameObject.AddComponent<FrozenOrbDOT>();
                    frozenOrbDOT.UpdateDOTInfo(10, 2, 0.2f);
                }
                break;
            case "WhistlingShield":
                //DamageOverTime.instance.ApplyFrost(this, 1);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        /*switch(other.transform.name){
            
            case "Mage_FlamePool(Clone)":
                inFlamePool = false;
            
                break;
        }*/
    }

    private void OnCollisionStay2D(Collision2D other) {
        
    }

   
}
