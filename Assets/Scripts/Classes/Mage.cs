using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    //The two classes are Elementalist and Battle Mage




    //cooldowns
    private float timerGoldenGodCooldown = 10;
    private float timerFlamePoolCooldown = 10;
    private float timerIceSpikeCooldown = 10;
    private float timerEarthWardenCooldown = 10;
    private float timerFrozenOrbCooldown = 10;
    private float timerFlowingWaterCooldown = 10;
    private float timerChainShockCooldown = 10;
    private float timerWillyShieldCooldown = 10;


    //timer starts
    private float timerGoldenGod = 0;
    private float timerFlamePool = 0;
    private float timerIceSpike = 0;
    private float timerEarthWarden = 0;
    private float timerFrozenOrb = 0;
    private float timerFlowingWater = 0;
    private float timerChainShock = 0;
    private float timerWillyShield = 0;


    private void Update()
    {
        GoldenGodTimer();
    }

    //Skill Implementations

    //Shared Mage Abilities
    void MirrorImage()
    {

    }

    //Elementalist Abilities

    //Normal Abilities
    void FlamePool()
    {

    }
    void IceSpike()
    {

    }
    void EarthWarden()
    {

    }
    void FrozenOrb()
    {

    }
    void FlowingWater()
    {

    }
    void ChainShock()
    {

    }
    void WhistlingShield()
    {

    }

    //Worthy Ability
    void GoldenGod()
    {

    }


    //Skill Timers, place in update when made
    void GoldenGodTimer()
    {
        if (timerGoldenGod <= 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GoldenGod();
                timerGoldenGod = timerGoldenGodCooldown;
            }
        }
        else
        {
            timerGoldenGod -= Time.deltaTime;
        }
    }
}
