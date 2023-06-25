using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeleeAI : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float rotateSpeed = 1f;
    public float attackRange = 0.5f;
    private Rigidbody2D rb;
    private float timeBetweenAttacks = 2f;

    public AnimationClip[] animations;
    public Animator anim;

    public Transform firingPointParent;
    public Transform meleePoint;
    public LayerMask playerMask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.FindGameObjectWithTag("Player")){
            target = GameObject.FindGameObjectWithTag("Player").transform;
            StartCoroutine(Attack());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.playerCanMove){
            Vector2 current = transform.position;
            Vector2 target2 = target.position;
            Vector2 v = target2 - current;
            float a = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            int index = (int)((Mathf.Round(a / 90f) + 4) % 4);
            anim.SetInteger("Index", index);
            

            transform.position = Vector2.MoveTowards(current, target2, speed * Time.deltaTime);

        }
        
    }

    private void Update() {
        RotateTowardsTarget();
    }

    private void RotateTowardsTarget(){
        Vector3 rotation = target.position - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg -90f;
        firingPointParent.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    IEnumerator Attack(){
        while (true){
            //Debug.Log("!!!!!!!!!!!!!!!!!!!!" + Physics2D.OverlapCircle(meleePoint.position, 1f, playerMask));
            Collider2D[] playerCollider = Physics2D.OverlapCircleAll(meleePoint.position, attackRange, playerMask);
            if (playerCollider.Length > 0){
                playerCollider[0].GetComponent<Player>().TakeDamage(2);
            }
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(meleePoint.position, attackRange);
    }
}
