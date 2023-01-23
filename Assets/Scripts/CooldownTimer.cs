using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTimer : MonoBehaviour
{
    float targetTime = 0f;

    public void StartTimer(float time)
    {
        targetTime = time;
    }

    private void Update()
    {
        targetTime -= Time.deltaTime;
    }

    public bool CheckTimerFinished()
    {
        if (targetTime <= 0f)
        {
            return true;
        }
        return false;
    }
}
