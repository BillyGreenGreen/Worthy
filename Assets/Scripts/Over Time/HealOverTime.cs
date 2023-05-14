using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealOverTime : MonoBehaviour
{
    private Player playerScript;

    public List<int> healTickTimers = new List<int>();

    public static HealOverTime instance;

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

    public void ApplyHeal(Player player, int ticks){
        playerScript = player;
        if(healTickTimers.Count <= 0){
            healTickTimers.Add(ticks);
            StartCoroutine(Heal());
        }
        else{
            healTickTimers.Add(ticks);
        }
    }

    IEnumerator Heal(){
        while(healTickTimers.Count > 0){
            for (int i = 0; i < healTickTimers.Count; i++)
            {
                healTickTimers[i]--;
            }
            if (playerScript.health < 100){
                playerScript.health += 5;
                //playerScript.healthBar.AddHealth(5);
            }
            
            healTickTimers.RemoveAll(number => number == 0);
            yield return new WaitForSeconds(2f);
        }
    }
}
