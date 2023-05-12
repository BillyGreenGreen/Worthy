using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHider : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> walls;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player"){
            foreach (SpriteRenderer wall in walls){
                Debug.Log("HIT");
                wall.color = new Color(1f, 1f, 1f, 0.13f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player"){
            foreach (SpriteRenderer wall in walls){
                Debug.Log("HIT");
                wall.color = new Color(255, 255, 255, 255);
            }
        }
    }
}
