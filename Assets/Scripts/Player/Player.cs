using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    private static Vignette vg;
    private static ChromaticAberration ca;
    private static LensDistortion ld;
    public HealthBarPlayer healthBar;
    public int maxHealth = 100;
    public int health = 100;
    public int shieldAmount;
    public float dodgeChance = 0f;

    public Collider2D colin;

    public TextMeshProUGUI healthText;

    private bool inMeleeRange = false;
    private float shieldTimer;
    private Dictionary<string, float> timers = new Dictionary<string, float>();

    GameObject gpp;
    Camera cam;
    GameObject playerSprite;

    //Golden God Cam Config
    public bool goldenGodStart = false;
    private float zoomDuration = 1.4f;
    float zoomStartValue = 2;
    float zoomEndValue = 6;
    float ldStartValue = 0.4f;
    float ldEndValue = 0;
    Vector3 spriteFloorPos = new Vector3(0,0,0);
    Vector3 spriteAirPos = new Vector3(0,0.1f,0);
    float timeElapsed = 0;

    private void Start() {
        gpp = GameObject.Find("Global Post Processing");
        gpp.GetComponent<Volume>().profile.TryGet(out ld);
        cam = Camera.main;
        playerSprite = GameObject.Find("PlayerSprite");
    }
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

        //Golden God Cam Stuff
        if (goldenGodStart){
            
            if (timeElapsed < zoomDuration){
                cam.orthographicSize = Mathf.Lerp(zoomStartValue, zoomEndValue, timeElapsed / zoomDuration);
                ld.intensity.value = Mathf.Lerp(ldStartValue, ldEndValue, timeElapsed / zoomDuration);
                playerSprite.transform.localPosition = Vector3.Lerp(spriteFloorPos, spriteAirPos, timeElapsed/zoomDuration);
                timeElapsed += Time.deltaTime;
                GameManager.instance.playerCanMove = false;
            }
            else{
                cam.orthographicSize = 6;
                ld.intensity.value = 0;
                goldenGodStart = false;
                GameManager.instance.playerCanMove = true;
            }
        }
        else{
            timeElapsed = 0;
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
        if (!GameManager.instance.goldenGodActive){

        
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
        
    }

    //colliding with other game objects that have physics
    private void OnCollisionEnter2D(Collision2D other) {
        if (GameManager.instance.goldenGodActive){
            Physics2D.IgnoreCollision(other.collider, colin);
        }
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
