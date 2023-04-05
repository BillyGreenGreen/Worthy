using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int shieldAmount;
    private void Update(){
        if (health <= 0){
            Die();
        }
    }

    private void Die(){
        //TODO
    }

    void OnTriggerEnter2D(Collider2D col) {
        //TODO: switch case for all damaging abilities to the player
        health -= 10;
        Debug.Log(col.transform.name);
    }
}
