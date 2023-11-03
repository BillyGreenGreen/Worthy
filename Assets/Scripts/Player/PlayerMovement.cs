using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // The speed of the player
    private Rigidbody2D rb; // The Rigidbody2D component attached to the player
    float horizontalInput;
    float verticalInput;
    public InputAction playerMovement;

    Vector2 movement = Vector2.zero;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on Start
        horizontalInput = 0;
        verticalInput = 0;
        playerMovement.ApplyBindingOverride(new InputBinding{
            path= "<Keyboard>/w",
            overridePath = "<Keyboard>/" + PlayerPrefs.GetString("MoveUp")
        });
        playerMovement.ApplyBindingOverride(new InputBinding{
            path= "<Keyboard>/s",
            overridePath = "<Keyboard>/" + PlayerPrefs.GetString("MoveDown")
        });
        playerMovement.ApplyBindingOverride(new InputBinding{
            path= "<Keyboard>/a",
            overridePath = "<Keyboard>/" + PlayerPrefs.GetString("MoveLeft")
        });
        playerMovement.ApplyBindingOverride(new InputBinding{
            path= "<Keyboard>/d",
            overridePath = "<Keyboard>/" + PlayerPrefs.GetString("MoveRight")
        });
    }

    private void OnEnable() {
        playerMovement.Enable();
    }

    private void OnDisable() {
        playerMovement.Disable();
    }

    void Update()
    {
        movement = playerMovement.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        if (GameManager.instance.playerCanMove){
            rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        }
        else{
            rb.velocity = new Vector2(0,0);
        }
    }
}
