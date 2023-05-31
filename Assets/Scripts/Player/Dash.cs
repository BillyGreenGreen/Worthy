using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Slider dashBar1;
    [SerializeField] private Slider dashBar2;

    [SerializeField] private TrailRenderer tr;

    private float dashTimer1;
    private float dashTimer2;

    //Will get this from upgrades when implemented
    private float dashTimerMax = 5;
    private bool isDashing;

    public float dashPower = 5f; // This does nothing, have to change the mass of the rigidbody, only way.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        dashTimer1 = dashTimerMax;
        dashTimer2 = dashTimerMax;
        dashBar1.maxValue = dashTimerMax;
        dashBar2.maxValue = dashTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (dashTimer1 < dashTimerMax){
            dashTimer1 += Time.deltaTime;
            dashBar1.value = dashTimer1;
        }
        if (dashTimer2 < dashTimerMax){
            dashTimer2 += Time.deltaTime;
            dashBar2.value = dashTimer2;
        }
        if (Input.GetKeyDown((KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("dash")))){
            if (dashTimer1 >= dashTimerMax){
                dashTimer1 = 0;
                //Dash implemmentation
                isDashing = true;
                
                //rb.velocity = dashDirection * 5f;
                //Debug.Log(rb.velocity);
            }
            else{
                if (dashTimer2 >= dashTimerMax){
                    dashTimer2 = 0;
                    isDashing = true;
                }
            }
        }
    }

    private void FixedUpdate() {
        if (isDashing){
            Vector2 dashDirection = rb.velocity;
            rb.AddForce(dashDirection * dashPower, ForceMode2D.Impulse);
            tr.emitting = true;
            isDashing = false;

        }
        else {
            tr.emitting = false;
        }
    }
}
