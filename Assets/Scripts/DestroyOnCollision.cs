using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy the projectile when it collides with any object
        Destroy(gameObject);
    }
}

