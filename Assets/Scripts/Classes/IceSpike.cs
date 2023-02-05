using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera cam;
    private Rigidbody2D rb;
    public float force;
    public Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        //probbably have to do rotation here or something
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }
}
