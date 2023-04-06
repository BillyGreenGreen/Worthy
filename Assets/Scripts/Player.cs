using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int shieldAmount;

    private float shieldTimer;
    private List<int> timers = new List<int>();
    private void Update(){
        shieldTimer -= Time.deltaTime;
        if (shieldAmount > 0){
            if (shieldTimer <= 0){
                shieldAmount = 0;
            }
        }
        if (shieldAmount < 0){
            shieldAmount = 0;
        }
        if (health <= 0){
            Die();
        }

        
    }

    private void Die(){
        //TODO
    }

    public void AddShield(int amount){
        shieldAmount = amount;
        shieldTimer = 10;
    }

    void OnTriggerEnter2D(Collider2D col) {
        //TODO: switch case for all damaging abilities to the player
        if (shieldAmount > 0){
            shieldAmount -= 10;
        }
        else{
            health -= 10;
        }
        
        Debug.Log(col.transform.name);
    }
}
