using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    //The two classes are Elementalist and Battle Mage

    //cooldowns
    private float timerGoldenGodCooldown = 10;
    private float timerFlamePoolCooldown = 6;
    private float timerIceSpikeCooldown = 3;
    private float timerEarthWardenCooldown = 10;
    private float timerFrozenOrbCooldown = 10;
    private float timerFlowingWaterCooldown = 10;
    private float timerChainShockCooldown = 10;
    private float timerWillyShieldCooldown = 10;


    //timer starts
    public float timerGoldenGod = 0;
    public float timerFlamePool = 0;
    public float timerIceSpike = 0;
    private float timerEarthWarden = 0;
    private float timerFrozenOrb = 0;
    private float timerFlowingWater = 0;
    private float timerChainShock = 0;
    private float timerWillyShield = 0;

    public GameObject IceSpikePrefab;
    public GameObject shootingPoint;


    List<string> abilities = new List<string>();

    private void Start()
    {
        for (int i = 0; i < GameManager.instance.GM_abilities.Count; i++)
        {

        }
    }

    private void Update()
    {
        GoldenGodTimer();
        IceSpikeTimer();
    }

    //Skill Implementations

    //Shared Mage Abilities
    void MirrorImage()
    {

    }

    //Elementalist Abilities
    void IceSpike()
    {

        GameObject projectile = Instantiate(IceSpikePrefab, shootingPoint.transform.position, Quaternion.identity);
    }
    void FlamePool()
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
    void IceSpikeTimer()
    {
        if (timerIceSpike <= 0 && GameManager.instance.GM_abilities.Contains("IceSpike"))
        {
            string keyCodeString = PlayerPrefs.GetString("ability" + (GameManager.instance.GM_abilities.FindIndex(a => a.Contains("IceSpike")) + 1).ToString());
            KeyCode parsedKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyCodeString, true);
            if (Input.GetKeyDown(parsedKeyCode))
            {
                IceSpike();
                timerIceSpike = timerIceSpikeCooldown;
            }
        }
        else
        {
            timerIceSpike -= Time.deltaTime;
        }
    }
    void GoldenGodTimer()
    {
        if (timerGoldenGod <= 0 && GameManager.instance.GM_abilities.Contains("GoldenGod"))
        {
            
            string keyCodeString = PlayerPrefs.GetString("ability" + (GameManager.instance.GM_abilities.FindIndex(a => a.Contains("GoldenGod")) + 1).ToString());
            KeyCode parsedKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyCodeString, true);
            if (Input.GetKeyDown(parsedKeyCode))
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
