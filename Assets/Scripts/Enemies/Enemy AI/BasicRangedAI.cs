using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRangedAI : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 1f;
    private Rigidbody2D rb;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;

    public float fireRate;
    private float timeToFire;

    public GameObject projectilePrefab;

    public Transform firingPointParent;
    public Transform firingPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindGameObjectWithTag("Player")){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void FixedUpdate() {
        
        if (Vector2.Distance(target.position, transform.position) >= distanceToStop){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }

    private void Update() {

        

        //if in earthwarden change target
        RotateTowardsTarget();
        if (Vector2.Distance(target.position, transform.position) <= distanceToShoot){
            Shoot();
        }
    }

    private void Shoot(){
        if (timeToFire <= 0f){
            Vector3 rotation = target.position - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg -90f;
            firingPointParent.rotation = Quaternion.Euler(0, 0, rotZ);
            //firingPoint.transform.Rotate(gameObject.transform.position, new Vector3(0,0,1), angle);
            Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            timeToFire = fireRate;
        }
        else{
            timeToFire -= Time.deltaTime;
        }
    }

    private void RotateTowardsTarget(){
        Vector2 targetDirection = target.position - transform.position;
        float rotZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        //float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0,0,rotZ));
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }
}
