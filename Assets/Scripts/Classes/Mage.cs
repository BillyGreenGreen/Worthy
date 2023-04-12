using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Mage
{
    
    //The two classes are Elementalist and Battle Mage


    public static void ActivateAbility(string name){
        switch (name){
            case "Mage_FlamePool":
                FlamePool();
                break;
            case "Mage_IceSpike":
                IceSpike();
                break;
            case "Mage_ChainShock":
                ChainShock();
                break;
            case "Mage_EarthWarden":
                EarthWarden();
                break;
            case "Mage_FlowingWater":
                FlowingWater();
                break;
            case "Mage_FrozenOrb":
                FrozenOrb();
                break;
            case "Mage_WhistlingShield":
                WhistlingShield();
                break;
            default:
                IceSpike();
                break;    
        }
    }

    //Skill Implementations
    //All damage numbers will be calculated on enemies by checking what they are colliding with

    //All duration abilities use GameManager.instance.AddAbilityInSceneTimer(prefab, duration);

    //Shared Mage Abilities
    static void MirrorImage()
    {

    }

    //Elementalist Abilities
    static void IceSpike()
    {
        Debug.Log("ICE SPIKE IN MAGE CLASS ACTIVATED");
        ProjectileShooter.instance.otherPrefab = (GameObject)Resources.Load("Prefabs/MageAbilities/Mage_IceSpike");
    }
    static void FlamePool()//DONE-ish doesnt work for multiple enemies, its because of the tick timers, needs to be different, maybe store in a dictionary for different abilities or enemies
    {
        Debug.Log("FLAME POOL IN MAGE CLASS ACTIVATED");

        float FlamePoolDuration = 7f;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        GameObject prefab = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/MageAbilities/Mage_FlamePool"), Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        GameManager.instance.AddDurationAbility(prefab, FlamePoolDuration);
    }
    static void ChainShock()
    {
        Debug.Log("CHAIN SHOCK IN MAGE CLASS ACTIVATED");
        ProjectileShooter.instance.otherPrefab = (GameObject)Resources.Load("Prefabs/MageAbilities/Mage_ChainShockProjectile");
        //Will hit an enemy, deal damage and check if there are other enemmies around it, if so it will send a function with a number of how many previous enemies it has hit
    }
    static void EarthWarden()//DONE
    {
        Debug.Log("EARTH WARDEN IN MAGE CLASS ACTIVATED");
        GameObject.Find("Player").GetComponent<Player>().AddShield(75, "EarthWarden");
    }
    static void FlowingWater()//DONE
    {
        HealOverTime.instance.ApplyHeal(GameObject.Find("Player").GetComponent<Player>(), 5);
    }
    static void FrozenOrb()//DONE
    {
        float FrozenOrbDuration = 5f;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        GameObject prefab = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/MageAbilities/Mage_FrozenOrb"), Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        GameManager.instance.AddDurationAbility(prefab, FrozenOrbDuration);
    }
    
    
    static void WhistlingShield()
    {
        //This will be earth warden shield but also does damage to enemies around the player/or thorns like ability
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Player>().AddShield(45, "WhistlingShield");
        Transform shield = player.transform.Find("WhistlingShield");
        shield.GetComponent<SpriteRenderer>().enabled = true;
        shield.GetComponent<CircleCollider2D>().enabled = true;


    }

    //Worthy Ability
    static void GoldenGod()
    {

    }

    
}
