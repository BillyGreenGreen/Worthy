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
            other.GetComponent<BasicRangedAI>().target = totem.transform;
            other.GetComponent<BasicRangedAI>().distanceToStop = 2f;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Enemy")){
            other.GetComponent<BasicRangedAI>().target = GameObject.FindGameObjectWithTag("Player").transform;
            other.GetComponent<BasicRangedAI>().distanceToStop = 8f;
        }
    }
}
