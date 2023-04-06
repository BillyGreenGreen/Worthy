using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    public int health = 300;
    
    public TextMeshProUGUI healthText;
    float timeColliding; //this will have to change with multiple duration abilities
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
    }

     private void OnCollisionEnter2D(Collision2D other) {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("COLLIDE :   " + other.transform.name);
        switch(other.transform.name){
            case "Mage_FlamePool(Clone)":
                DamageOverTime.instance.ApplyBurn(this, 3);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        switch(other.transform.name){
            case "Mage_FlamePool(Clone)":
            Debug.Log("STAY:   " + health);
            health -= Convert.ToInt32(Math.Floor(10 * Time.deltaTime));
            /*timeColliding += Time.fixedDeltaTime;
                if (timeColliding > 1f){
                    health -= 10;
                    timeColliding = 0f;
                }*/
            break;
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        
    }

   
}
