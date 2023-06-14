using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    [Header("Health")]
    public int health = 300;
    public TextMeshProUGUI healthText;

    float timeColliding; //this will have to change with multiple duration abilities
    
    [Header("Mage Abilities")]
    public Collider2D chainShockRadiusCheck;
    bool inFlamePool = false;
    public bool hitByChainShock = false;
    public float chainShockTimer = 0f;

    [Header("Debuffs")]
    public GameObject debuffIcons;
    List<GameObject> otherEnemies;
    public bool flamePoolDebuffRemove = false;
    public bool frozenOrbDebuffRemove = false;

    private string powerPotionLevel;

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
            if (debuffIcons.transform.Find("ChainShockDebuff(Clone)") != null){
                Transform remove = debuffIcons.transform.Find("ChainShockDebuff(Clone)");
                Destroy(remove.gameObject);
            }
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

        powerPotionLevel = GameManager.instance.powerPotionLevel;
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
                if (debuffIcons.transform.Find("FlamePoolDebuff(Clone)") == null){
                    GameObject icon = Instantiate(Resources.Load<GameObject>("Prefabs/MageAbilities/Debuffs/FlamePoolDebuff"), new Vector3(0,0,0), Quaternion.identity);
                    icon.transform.SetParent(debuffIcons.transform);
                    flamePoolDebuffRemove = false;
                }
                
                FlamePoolDOT flamePoolDOT = gameObject.AddComponent<FlamePoolDOT>();

                //Potion of Power
                if (powerPotionLevel == "Medium"){
                    flamePoolDOT.UpdateDOTInfo(3, 10, 1);//ticks, damagePerTick, timeBetweenTicks
                }
                else if (powerPotionLevel == "High"){
                    flamePoolDOT.UpdateDOTInfo(3, 20, 1);//ticks, damagePerTick, timeBetweenTicks
                }
                else if (powerPotionLevel == "Worthy"){
                    flamePoolDOT.UpdateDOTInfo(3, 40, 1);//ticks, damagePerTick, timeBetweenTicks
                }
                else if (powerPotionLevel == "None"){
                    flamePoolDOT.UpdateDOTInfo(3, 10, 1);//ticks, damagePerTick, timeBetweenTicks
                }
                break;

            case "FrozenOrbRing":
                if (debuffIcons.transform.Find("FrozenOrbDebuff(Clone)") == null){
                    GameObject icon = Instantiate(Resources.Load<GameObject>("Prefabs/MageAbilities/Debuffs/FrozenOrbDebuff"), new Vector3(0,0,0), Quaternion.identity);
                    icon.transform.SetParent(debuffIcons.transform);
                    frozenOrbDebuffRemove = false;
                }
                FrozenOrbDOT frozenOrbDOT = gameObject.AddComponent<FrozenOrbDOT>();
                if (powerPotionLevel == "Medium"){
                    frozenOrbDOT.UpdateDOTInfo(10, 4, 0.2f);
                }
                else if (powerPotionLevel == "High"){
                    frozenOrbDOT.UpdateDOTInfo(10, 10, 0.2f);
                }
                else if (powerPotionLevel == "Worthy"){
                    frozenOrbDOT.UpdateDOTInfo(10, 32, 0.2f);
                }
                else if (powerPotionLevel == "None"){
                    frozenOrbDOT.UpdateDOTInfo(10, 2, 0.2f);
                }
                
                break;
            
                
            case "WhistlingShield":
                WhistlingShieldDOT whistlingShieldDOT = gameObject.AddComponent<WhistlingShieldDOT>();
                if (powerPotionLevel == "Medium"){
                    whistlingShieldDOT.UpdateDOTInfo(12, 2, 0.1f);
                }
                else if (powerPotionLevel == "High"){
                    whistlingShieldDOT.UpdateDOTInfo(12, 6, 0.1f);
                }
                else if (powerPotionLevel == "Worthy"){
                    whistlingShieldDOT.UpdateDOTInfo(12, 15, 0.1f);
                }
                else if (powerPotionLevel == "None"){
                    whistlingShieldDOT.UpdateDOTInfo(12, 1, 0.1f);
                }
                
                break;
            case "Mage_IceSpike(Clone)":
                if (powerPotionLevel == "High" || powerPotionLevel == "None" || powerPotionLevel == "Medium"){
                    health -= 30;
                }
                else if (powerPotionLevel == "Worthy"){
                    health -= 60;
                }
                
                Destroy(other.gameObject);
                break;
            case "Mage_ChainShockProjectile(Clone)":
                hitByChainShock = true;
                HitByChainShock(4); //parameter is how many enemies can be hit by chain shock, will be changed with a GM_***** variable
                Destroy(other.gameObject);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        switch(other.transform.name){
            
            case "Mage_FlamePool(Clone)":
                if (gameObject.GetComponent<FlamePoolDOT>() == null){
                    flamePoolDebuffRemove = false;
                    FlamePoolDOT flamePoolDOT = gameObject.AddComponent<FlamePoolDOT>();
                    if (powerPotionLevel == "Medium"){
                    flamePoolDOT.UpdateDOTInfo(3, 10, 1);//ticks, damagePerTick, timeBetweenTicks
                    }
                    else if (powerPotionLevel == "High"){
                        flamePoolDOT.UpdateDOTInfo(3, 20, 1);//ticks, damagePerTick, timeBetweenTicks
                    }
                    else if (powerPotionLevel == "Worthy"){
                        flamePoolDOT.UpdateDOTInfo(3, 40, 1);//ticks, damagePerTick, timeBetweenTicks
                    }
                    else if (powerPotionLevel == "None"){
                        flamePoolDOT.UpdateDOTInfo(3, 10, 1);//ticks, damagePerTick, timeBetweenTicks
                    }
                }
                break;
            case "FrozenOrbRing":
                if (gameObject.GetComponent<FrozenOrbDOT>() == null){
                    frozenOrbDebuffRemove = false;
                    FrozenOrbDOT frozenOrbDOT = gameObject.AddComponent<FrozenOrbDOT>();
                    if (powerPotionLevel == "Medium"){
                    frozenOrbDOT.UpdateDOTInfo(10, 4, 0.2f);
                    }
                    else if (powerPotionLevel == "High"){
                        frozenOrbDOT.UpdateDOTInfo(10, 10, 0.2f);
                    }
                    else if (powerPotionLevel == "Worthy"){
                        frozenOrbDOT.UpdateDOTInfo(10, 32, 0.2f);
                    }
                    else if (powerPotionLevel == "None"){
                        frozenOrbDOT.UpdateDOTInfo(10, 2, 0.2f);
                    }
                }
                break;
            case "WhistlingShield":
                if (gameObject.GetComponent<WhistlingShieldDOT>() == null){
                    WhistlingShieldDOT whistlingShieldDOT = gameObject.AddComponent<WhistlingShieldDOT>();
                    if (powerPotionLevel == "Medium"){
                    whistlingShieldDOT.UpdateDOTInfo(12, 2, 0.1f);
                    }
                    else if (powerPotionLevel == "High"){
                        whistlingShieldDOT.UpdateDOTInfo(12, 6, 0.1f);
                    }
                    else if (powerPotionLevel == "Worthy"){
                        whistlingShieldDOT.UpdateDOTInfo(12, 15, 0.1f);
                    }
                    else if (powerPotionLevel == "None"){
                        whistlingShieldDOT.UpdateDOTInfo(12, 1, 0.1f);
                    }
                }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        switch(other.transform.name){
            case "Mage_FlamePool(Clone)":
                flamePoolDebuffRemove = true;
                break;
            case "WhistlingShield":
                gameObject.GetComponent<WhistlingShieldDOT>().DestroyDOT();
                break;
            case "FrozenOrbRing":
                frozenOrbDebuffRemove = true;
                gameObject.GetComponent<FrozenOrbDOT>().DestroyDOT();
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        
    }

    public void HitByChainShock(int numberOfHitsLeft){
        if (hitByChainShock && numberOfHitsLeft > 0){
            if (debuffIcons.transform.Find("ChainShockDebuff(Clone)") == null){
                GameObject icon = Instantiate(Resources.Load<GameObject>("Prefabs/MageAbilities/Debuffs/ChainShockDebuff"), new Vector3(0,0,0), Quaternion.identity);
                icon.transform.SetParent(debuffIcons.transform);
                //chainShockTimer = 10f; chain shock timer reset here if we dont want it to refresh afer being shot again, ask opinions
            }
            chainShockTimer = 10f;
            if (powerPotionLevel == "Medium"){
                health -= 20;
            }
            else if (powerPotionLevel == "High"){
                health -= 50;
            }
            else if (powerPotionLevel == "Worthy"){
                health -= 100;
            }
            else if (powerPotionLevel == "None"){
                health -= 20;
            }
            
            
            
            int count = numberOfHitsLeft;
            foreach(GameObject otherEnemy in chainShockRadiusCheck.GetComponent<ChainShockRadiusChecker>().otherEnemies){
                if (!otherEnemy.GetComponent<Enemy>().hitByChainShock){
                    otherEnemy.GetComponent<Enemy>().hitByChainShock = true;
                    count--;
                    otherEnemy.GetComponent<Enemy>().HitByChainShock(count);
                }
            }
        }
    }

   
}
