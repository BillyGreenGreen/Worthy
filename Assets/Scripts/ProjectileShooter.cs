using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // the prefab for the projectile
    public float projectileSpeed; // the speed at which the projectile will travel
    public GameObject shootingPoint;
    public BoxCollider2D box;
    private Camera cam;
    private Vector3 mousePos;

    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        //print(mousePos);
        // check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0) && !box.OverlapPoint(new Vector2(mousePos.x, mousePos.y)))
        {
            // create a new projectile at the position of the object this script is attached to
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.transform.position, Quaternion.identity);
        }
    }
}
