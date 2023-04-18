using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenOrbDOT : MonoBehaviour
{
    public List<int> burnTickTimers = new List<int>();

    private int ticks;
    private int damagePerTick;
    private float timeBetweenTicks;


    // Start is called before the first frame update
    private void Start(){
        ApplyBurn();
    }

    public void UpdateDOTInfo(int ticks, int damagePerTick, float timeBetweenTicks){
        this.ticks = ticks;
        this.damagePerTick = damagePerTick;
        this.timeBetweenTicks = timeBetweenTicks;
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

    public void DestroyDOT(){
        if (gameObject.GetComponent<Enemy>().frozenOrbDebuffRemove){
            Transform remove = gameObject.GetComponent<Enemy>().debuffIcons.transform.Find("FrozenOrbDebuff(Clone)");
            Destroy(remove.gameObject);
        } 
        Destroy(this);
    }

    IEnumerator Damage(){
        while(burnTickTimers.Count > 0){
            for (int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            gameObject.GetComponent<Enemy>().health -= damagePerTick;
            burnTickTimers.RemoveAll(number => number == 0);
            yield return new WaitForSeconds(timeBetweenTicks);
        }
        Destroy(this);
    }
}
