using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    Image cooldownOverlay;
    [SerializeField]
    TextMeshProUGUI chargesUIText;
    [SerializeField]
    TextMeshProUGUI cooldownUIText;
    public float dashDistance = 5f; // The distance the player will dash
    public float dashTime = 0.5f; // The duration of the dash
    public int maxCharges = 2; // The maximum number of dash charges
    public float dashRechargeTime = 2f;
    public float cooldownTimer;
    public int charges; // The current number of dash charges
    private float dashTimer; // A timer to track the duration of the dash
    private bool isDashing; // A flag to track whether the player is currently dashing
    private Rigidbody2D rb; // The Rigidbody2D component attached to the player
    private Vector2 dashDirection; // The direction the player will dash in

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on Start
        charges = maxCharges; // Set the initial number of dash charges to the maximum
    }

    void Update()
    {
        chargesUIText.text = charges.ToString();
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0)
        {
            int cooldown = (int)cooldownTimer;
            cooldownUIText.text = cooldown.ToString();
        }
        else
        {
            cooldownUIText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Space) && charges > 0) // Check if the player pressed the dash button, is not already dashing, is not on dash cooldown, and has at least one dash charge
        {
            // Get the direction the player is moving
            //dashDirection = rb.velocity;

            Vector3 cursorScreenSpace = Input.mousePosition;

            // Convert the mouse cursor position from screen space to world space
            Vector3 cursorWorldSpace = Camera.main.ScreenToWorldPoint(cursorScreenSpace);

            // Get the direction from the player to the mouse cursor
            dashDirection = cursorWorldSpace - transform.position;

            // Start the dash
            StartCoroutine(Dash());
        }
        cooldownOverlay.fillAmount = Mathf.Clamp01(cooldownTimer / dashRechargeTime);
    }

    IEnumerator Dash()
    {
        if (!(cooldownTimer < 3 && cooldownTimer > 0))
        {
            cooldownTimer = 3f;
        }
        
        isDashing = true; // Set the dash flag to true
        charges--; // Decrement the number of dash charges
        dashTimer = dashTime; // Set the dash timer to the dash duration

        while (dashTimer > 0) // While the dash timer is greater than zero
        {
            // Reduce the dash timer by the time elapsed since the last frame
            dashTimer -= Time.deltaTime;

            // Set the velocity of the Rigidbody2D to the dash direction multiplied by the dash distance and speed
            rb.velocity = dashDirection.normalized * dashDistance / dashTime;

            yield return null; // Wait until the next frame
        }

        // Reset the dash flag and velocity when the dash is finished
        isDashing = false;
        rb.velocity = Vector2.zero;
        StartCoroutine(RechargeDash());
    }

    IEnumerator RechargeDash()
    {
        // Wait for the dash recharge time
        yield return new WaitForSeconds(dashRechargeTime);

        // Increment the number of current dashes by 1
        charges++;

        // Clamp the number of current dashes to the maximum
        charges = Mathf.Clamp(charges, 0, maxCharges);
    }
}
