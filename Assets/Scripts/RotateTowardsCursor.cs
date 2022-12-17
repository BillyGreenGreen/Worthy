using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCursor : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites = new Sprite[8];
    
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        // Get the position of the mouse cursor in screen space
        Vector3 cursorScreenSpace = Input.mousePosition;

        // Convert the mouse cursor position from screen space to world space
        Vector3 cursorWorldSpace = Camera.main.ScreenToWorldPoint(cursorScreenSpace);

        // Get the direction from the player to the mouse cursor
        Vector2 direction = cursorWorldSpace - transform.position;

        // Get the angle of the direction in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle <= 20 && angle >= -20)//look right
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (angle >= 20 && angle <= 70)//look up_right
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (angle >= 70 && angle <= 110)//look up
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (angle >= 110 && angle <= 160)//look up_left
        {
            spriteRenderer.sprite = sprites[3];
        }
        else if (angle >= 160 || angle <= -160)//look left
        {
            spriteRenderer.sprite = sprites[4];
        }
        else if (angle <= -110 && angle >= -160)//look down_left
        {
            spriteRenderer.sprite = sprites[5];
        }
        else if (angle <= -70 && angle >= -110)//look down
        {
            spriteRenderer.sprite = sprites[6];
        }
        else if (angle <= -20 && angle >= -70)//look down_right
        {
            spriteRenderer.sprite = sprites[7];
        }


        // Rotate the player towards the mouse cursor
        //transform.rotation = Quaternion.Euler(0f, 0f, angle);
        
    }
}
