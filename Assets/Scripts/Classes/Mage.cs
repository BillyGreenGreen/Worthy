using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            default:
                IceSpike();
                break;    
        }
    }

    //Skill Implementations

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
    static void FlamePool()
    {
        Debug.Log("FLAME POOL IN MAGE CLASS ACTIVATED");
    }
    static void ChainShock()
    {
        Debug.Log("CHAIN SHOCK IN MAGE CLASS ACTIVATED");
    }
    static void EarthWarden()
    {

    }
    static void FrozenOrb()
    {

    }
    static void FlowingWater()
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
