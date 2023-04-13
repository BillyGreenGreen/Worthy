using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageOverTime : MonoBehaviour
{
    private Enemy enemyScript;

    public List<int> burnTickTimers = new List<int>();

    private int ticks;
    private int damagePerTick;
    private float timeBetweenTicks;
    public string damageType;



    private void Awake() {
        ApplyBurn();
    }

    private void Update() {
        
    }

    public void UpdateDOTInfo(int ticks, int damagePerTick, float timeBetweenTicks, string damageType){
        this.ticks = ticks;
        this.damagePerTick = damagePerTick;
        this.timeBetweenTicks = timeBetweenTicks;
        this.damageType = damageType;
    }

    public void ApplyBurn(){
        if(burnTickTimers.Count <= 0){
            burnTickTimers.Add(ticks);
            StartCoroutine(Damage());
        }
        else{
            burnTickTimers.Add(ticks);
        }
    }

    IEnumerator Damage(){
        while(burnTickTimers.Count > 0){
            for (int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            if (gameObject.GetComponent<Enemy>() != null){
            gameObject.GetComponent<Enemy>().health -= damagePerTick;
            }
            burnTickTimers.RemoveAll(number => number == 0);
            yield return new WaitForSeconds(timeBetweenTicks);
        }
        Destroy(this);
    }
}
