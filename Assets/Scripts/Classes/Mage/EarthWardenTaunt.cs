using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EarthWardenTaunt : MonoBehaviour
{
    public Transform totem;

    //trigger is outer circle
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")){
            if (other.GetComponent<BasicRangedAI>() != null){
                other.GetComponent<BasicRangedAI>().target = totem.transform;
                other.GetComponent<BasicRangedAI>().distanceToStop = 2f;
            }
            else if (other.GetComponent<BasicMeleeAI>() != null){
                other.GetComponent<BasicMeleeAI>().target = totem.transform;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Enemy")){
            if (other.GetComponent<BasicRangedAI>() != null){
                other.GetComponent<BasicRangedAI>().target = GameObject.FindGameObjectWithTag("Player").transform;
                other.GetComponent<BasicRangedAI>().distanceToStop = 8f;
            }
            else if (other.GetComponent<BasicMeleeAI>() != null){
                other.GetComponent<BasicMeleeAI>().target = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
    }
}
