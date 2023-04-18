using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotemHealthBar : MonoBehaviour
{
    float health = 1000;
    public TextMeshProUGUI healthText;

    private void Update() {
        if (health <= 0){
            Destroy(transform.root.gameObject);
        }
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("EnemyProjectile")){
            health -= 100;
            Destroy(other.gameObject);
        }
    }
}
