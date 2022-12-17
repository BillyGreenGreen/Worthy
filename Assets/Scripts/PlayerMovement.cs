using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // The speed of the player
    private Rigidbody2D rb; // The Rigidbody2D component attached to the player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on Start
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get the horizontal input from the user
        float verticalInput = Input.GetAxis("Vertical"); // Get the vertical input from the user

        Vector2 movement = new Vector2(horizontalInput, verticalInput); // Create a Vector2 to store the movement input

        rb.velocity = movement * speed; // Set the velocity of the Rigidbody2D to the movement input multiplied by the speed
    }
}
