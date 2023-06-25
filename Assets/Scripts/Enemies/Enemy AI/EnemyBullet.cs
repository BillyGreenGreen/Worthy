using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Rigidbody2D rb;
    public float force;
    private float minForce = 10f;
    private float maxForce = 15f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = Random.Range(minForce, maxForce);
    }

    private void FixedUpdate() {
        rb.velocity = transform.up * force;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch(other.tag){
            case "OuterWall":
                Destroy(gameObject);
                break;
        }
    }
}
