using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    // Set these in the Inspector
    public float dashDistance = 5f;
    public float dashDuration = 0.5f;
    public int maxDashes = 2;
    public float dashRechargeTime = 2f;

    // These variables are for internal use
    public int currentDashes;
    private float lastDashTime;
    private Rigidbody2D rb;
    private Vector2 dashDirection;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Set the number of current dashes to the maximum
        currentDashes = maxDashes;
    }

    void Update()
    {
        // Check if the player has pressed the dash button
        // Replace "Fire1" with the name of your dash button
        if (Input.GetButtonDown("Fire1"))
        {
            // Check if the player has any dashes left and if enough time has passed since the last dash
            if (currentDashes > 0 && Time.time - lastDashTime > dashRechargeTime)
            {
                // Reduce the number of current dashes by 1
                currentDashes--;

                // Save the time of the dash
                lastDashTime = Time.time;

                // Set the dash direction to the current movement direction
                dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

                // Start the dash coroutine
                StartCoroutine(DoDash());
            }
        }
    }

    IEnumerator DoDash()
    {
        // Set the player's velocity to the dash direction
        rb.velocity = dashDirection * dashDistance / dashDuration;

        // Wait for the dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reset the player's velocity
        rb.velocity = Vector2.zero;

        // Start the recharge coroutine
        
    }

    
}
