using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    //The two classes are Elementalist and Battle Mage

    CooldownTimer goldenGodTimer = new CooldownTimer();
    void GoldenGod()
    {
        
    }

    private void Start()
    {
        goldenGodTimer.StartTimer(2.0f);
    }

    private void Update()
    {
        print(goldenGodTimer.CheckTimerFinished());
    }
}
