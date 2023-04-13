using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public static ProjectileShooter instance;
    public GameObject projectilePrefab; // the prefab for the projectile
    public float projectileSpeed; // the speed at which the projectile will travel
    public GameObject shootingPoint;
    //public BoxCollider2D box;
    public GameObject otherPrefab;
    private Camera cam;
    private Vector3 mousePos;


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        cam = Camera.main;
        otherPrefab = null;
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        //print(mousePos);
        // check if the left mouse button is pressed
        //&& !box.OverlapPoint(new Vector2(mousePos.x, mousePos.y)
        if (Input.GetMouseButtonDown(0))
        {
            // create a new projectile at the position of the object this script is attached to
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.transform.position, Quaternion.identity);
        }
        else if(otherPrefab != null){
            GameObject projectile = Instantiate(otherPrefab, shootingPoint.transform.position, Quaternion.identity);
            otherPrefab = null;
        }
    }
}
