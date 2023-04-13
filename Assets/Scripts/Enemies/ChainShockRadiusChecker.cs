using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainShockRadiusChecker : MonoBehaviour
{
    public List<GameObject> otherEnemies = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy"){
            otherEnemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Enemy"){
            otherEnemies.Remove(other.gameObject);
        }
    }
}
