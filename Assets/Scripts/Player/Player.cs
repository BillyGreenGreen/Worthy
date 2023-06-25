using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public HealthBarPlayer healthBar;
    public int maxHealth = 100;
    public int health = 100;
    public int shieldAmount;
    public float dodgeChance = 0f;

    public TextMeshProUGUI healthText;

    private bool inMeleeRange = false;
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
                if (timer == "WhistlingShield"){
                    shieldAmount -= 45;
                    GameObject player = GameObject.Find("Player");
                    Transform shield = player.transform.Find("WhistlingShield");
                    shield.GetComponent<SpriteRenderer>().enabled = false;
                    shield.GetComponent<CircleCollider2D>().enabled = false;
                    healthBar.SetShield(0);
                }
            }
        }

        if (shieldAmount > 0){
            healthText.text = health.ToString() + " (" + shieldAmount +")";
            healthBar.SetShield(shieldAmount);
        }
        else{
            healthText.text = health.ToString();
            healthBar.SetHealth(health);
        }
        if (shieldAmount < 0){
            shieldAmount = 0;
            healthBar.SetShield(0);
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
        //healthBar.AddShield(amount);
        
        if (abilityName == "EarthWarden"){
            timers.Add(abilityName, 10);
        }
        else if (abilityName == "WhistlingShield"){
            timers.Add(abilityName, 6);
        }
    }

    public void TakeDamage(int damage){
        if (dodgeChance > 0){
            float rng = Random.Range(1, 101);
            if (rng >= dodgeChance){
                if (shieldAmount > 0){
                shieldAmount -= damage;
                //healthBar.RemoveShield(damage);
                }
                else{
                    health -= damage;
                    //healthBar.RemoveHealth(damage);
                }
            }
            else{
                Debug.Log("DODGED");
            }
        }
        else{
            if (shieldAmount > 0){
                shieldAmount -= damage;
                //healthBar.RemoveShield(damage);
            }
            else{
                health -= damage;
                //healthBar.RemoveHealth(damage);
            }
        }
        
    }

    //colliding with other game objects that have physics
    private void OnCollisionEnter2D(Collision2D other) {
        switch(other.transform.tag){
            
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        //TODO: switch case for all damaging abilities to the player
        switch(col.transform.tag){
            case "EnemyProjectile":
                TakeDamage(5);
                Destroy(col.gameObject);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
    }

  
}
