using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    public int health = 300;
    public TextMeshProUGUI healthText;
    float timeColliding; //this will have to change with multiple duration abilities
    public Collider2D chainShockRadiusCheck;
    bool inFlamePool = false;
    public bool hitByChainShock = false;
    public float chainShockTimer = 0f;
    List<GameObject> otherEnemies;

    private void Start() {
    }

    
    // Update is called once per frame
    void Update()
    {
        if (chainShockTimer > 0){
            chainShockTimer -= Time.deltaTime;
        }
        else if(chainShockTimer <= 0){
            hitByChainShock = false;
        }
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

    private void OnDrawGizmosSelected() {
        //Gizmos.color = new Color(255, 255, 255, 0.5f);
        //Gizmos.DrawSphere(gameObject.transform.position, 1);
    }

    //    All damage numbers for enemies below
    //    Provide ticks, damagePerTick and timeBetweenTicks below
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("COLLIDE :" + other.transform.name);
        switch(other.transform.name){
            case "Mage_FlamePool(Clone)":
                FlamePoolDOT flamePoolDOT = gameObject.AddComponent<FlamePoolDOT>();
                flamePoolDOT.UpdateDOTInfo(3, 10, 1);//ticks, damagePerTick, timeBetweenTicks
                break;
            case "Mage_FrozenOrb(Clone)":
                FrozenOrbDOT frozenOrbDOT = gameObject.AddComponent<FrozenOrbDOT>();
                frozenOrbDOT.UpdateDOTInfo(10, 2, 0.2f);
                break;
            
                
            case "WhistlingShield":
                WhistlingShieldDOT whistlingShieldDOT = gameObject.AddComponent<WhistlingShieldDOT>();
                whistlingShieldDOT.UpdateDOTInfo(12, 1, 0.1f);
                break;
            case "Mage_IceSpike(Clone)":
                health -= 5;
                Destroy(other.gameObject);
                break;
            case "Mage_ChainShockProjectile(Clone)":
                hitByChainShock = true;
                HitByChainShock();
                Destroy(other.gameObject);
                break;
        }
    }

    //Sort of works, deletes other object, what we could do if send another projectile towards the other object because thats what it will do in the end
    public void HitByChainShock(){
        if (hitByChainShock){
            otherEnemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
            GameObject closestEnemy = null;
            otherEnemies.Remove(gameObject);
            foreach (GameObject enemy in otherEnemies){
                if (Vector3.Distance(gameObject.transform.position, enemy.transform.position) < 10){
                    if (closestEnemy != null){
                        if (!closestEnemy.GetComponent<Enemy>().hitByChainShock && Vector3.Distance(gameObject.transform.position, enemy.transform.position) < Vector3.Distance(gameObject.transform.position, closestEnemy.transform.position)){
                            closestEnemy = enemy;
                        }
                    }
                    else{
                        closestEnemy = enemy;
                    }
                }
            }
            health -= 20;
            chainShockTimer = 10f;
            if (closestEnemy != null){
                //Debug.Log(closestEnemy.name);
                closestEnemy.GetComponent<Enemy>().hitByChainShock = true;
                closestEnemy.GetComponent<Enemy>().HitByChainShock();
            }
            else{
                Debug.Log("NO ENEMIES CLOSE ENOUGH");
            }
            
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
                if (gameObject.GetComponent<WhistlingShieldDOT>() == null){
                    WhistlingShieldDOT whistlingShieldDOT = gameObject.AddComponent<WhistlingShieldDOT>();
                    whistlingShieldDOT.UpdateDOTInfo(12, 1, 0.1f);
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        switch(other.transform.name){
            case "WhistlingShield":
                gameObject.GetComponent<WhistlingShieldDOT>().Destroy();
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        
    }

   
}
