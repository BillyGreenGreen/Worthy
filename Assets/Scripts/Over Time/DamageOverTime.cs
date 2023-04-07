using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageOverTime : MonoBehaviour
{
    private Enemy enemyScript;

    public List<int> burnTickTimers = new List<int>();
    public List<int> frostTickTimers = new List<int>();

    public static DamageOverTime instance;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    private void Start(){
    }

    public void ApplyFrost(Enemy enemy, int ticks){
        enemyScript = enemy;
        if(frostTickTimers.Count <= 0){
            frostTickTimers.Add(ticks);
            StartCoroutine(Frost());
        }
        else{
            frostTickTimers.Add(ticks);
        }
    }

    IEnumerator Frost(){
        while(frostTickTimers.Count > 0){
            for (int i = 0; i < frostTickTimers.Count; i++)
            {
                frostTickTimers[i]--;
            }
            enemyScript.health -= 2;
            frostTickTimers.RemoveAll(number => number == 0);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ApplyBurn(Enemy enemy, int ticks){
        enemyScript = enemy;
        if(burnTickTimers.Count <= 0){
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else{
            burnTickTimers.Add(ticks);
        }
    }

    IEnumerator Burn(){
        while(burnTickTimers.Count > 0){
            for (int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            enemyScript.health -= 10;
            burnTickTimers.RemoveAll(number => number == 0);
            yield return new WaitForSeconds(1f);
        }
    }
}
