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
        //GameObject projectile = Instantiate(IceSpikePrefab, shootingPoint.transform.position, Quaternion.identity);
    }
    static void FlamePool()//DONE
    {
        Debug.Log("FLAME POOL IN MAGE CLASS ACTIVATED");

        float FlamePoolDuration = 3f;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        GameObject prefab = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/MageAbilities/Mage_FlamePool"), Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        GameManager.instance.AddDurationAbility(prefab, FlamePoolDuration);
    }
    static void ChainShock()
    {
        Debug.Log("CHAIN SHOCK IN MAGE CLASS ACTIVATED");
    }
    static void EarthWarden()//DONE
    {
        Debug.Log("EARTH WARDEN IN MAGE CLASS ACTIVATED");
        GameObject.Find("Player").GetComponent<Player>().AddShield(100);
    }
    static void FlowingWater()//DONE
    {
        HealOverTime.instance.ApplyHeal(GameObject.Find("Player").GetComponent<Player>(), 5);
    }
    static void FrozenOrb()
    {

    }
    
    
    static void WhistlingShield()
    {

    }

    //Worthy Ability
    static void GoldenGod()
    {

    }

    
}
