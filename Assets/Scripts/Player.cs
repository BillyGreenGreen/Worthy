using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int shieldAmount;

    public TextMeshProUGUI healthText;

    private float shieldTimer;
    private Dictionary<string, float> timers = new Dictionary<string, float>();
    private void Update(){
        List<string> timersCopy = new List<string>(timers.Keys);
        foreach (string timer in timersCopy){
            if (timers[timer] >= 0){
                timers[timer] -= Time.deltaTime;
            }
            else{
                timers.Remove(timer);
                if (timer == "EarthWarden"){
                    shieldAmount -= 75;
                }
                if (timer == "WhistlingShield"){
                    shieldAmount -= 45;
                    GameObject player = GameObject.Find("Player");
                    Transform shield = player.transform.Find("WhistlingShield");
                    shield.GetComponent<SpriteRenderer>().enabled = false;
                    shield.GetComponent<CircleCollider2D>().enabled = false;

                }
            }
        }

        if (shieldAmount > 0){
            healthText.text = health.ToString() + " (" + shieldAmount +")";
        }
        else{
            healthText.text = health.ToString();
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

    public void AddShield(int amount, string abilityName){
        shieldAmount += amount;
        
        if (abilityName == "EarthWarden"){
            timers.Add(abilityName, 10);
        }
        else if (abilityName == "WhistlingShield"){
            timers.Add(abilityName, 6);
        }
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
