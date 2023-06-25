using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player"){
            //other.GetComponent<Player>().TakeDamage()
        }
    }
}
