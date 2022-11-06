using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    //public float walkRange = 10;
    public Animator animator;
    //public float walkSpeed = 4;
    public float runSpeed = 8;
    public float walkSpeed;
    private bool isWalking = false;
    private Vector3 direction = Vector3.zero;
    private Vector3 destination;
    public float patrolDistance = 2;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceBetweenTarget = Vector3.Distance(transform.position, target.position);

        if(currentState == "IdleState")
        {
            if (distanceBetweenTarget < chaseRange)
            {
                currentState = "RunState";
            }
            else
            {
                if (!isWalking)
                {
                    StartCoroutine(changeDirection());
                }

                destination = transform.position + direction * patrolDistance;
                //transform.position += direction * walkSpeed * Time.deltaTime;
                if (transform.position.x > destination.x)
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                }
                else if (transform.position.x < destination.x)
                {
                    transform.rotation = Quaternion.Euler(0, -270, 0);
                }
                transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime);
            }

        }
        /*else if(currentState == "WalkState")
        {
            animator.SetTrigger("Walk");

            //Move Left
            if (target.position.x > transform.position.x)
            {
                transform.Translate(-transform.right * walkSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -270, 0);
            }
            //Move Right
            else
            { 
                transform.Translate(transform.right * walkSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }

            if(distanceBetweenTarget < chaseRange)
            {
                currentState = "RunState";
            }
        }*/
        else if (currentState == "RunState")
        {
            animator.SetTrigger("Chase");

            //Move Left
            if(target.position.x > transform.position.x)
            {
                transform.Translate(-transform.right * runSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -270, 0);
            }
            //Move Right
            else
            {
                transform.Translate(transform.right * runSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }

            if(distanceBetweenTarget > chaseRange)
            {
                currentState = "IdleState";
            }
        }

    }


    //Check if the enemy got hit by a bullet
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerProjectile")
        {
            StartCoroutine(EnemyDeath());
        }
    }


    IEnumerator EnemyDeath()
    {
        currentState = "Die";
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    IEnumerator changeDirection()
    {
        if (direction.x == 0)
        {
            animator.SetTrigger("Idle");
        }
        else
        {
            animator.SetTrigger("Walk");
        }

        isWalking = true;
        yield return new WaitForSeconds(2);
        direction.x = Random.Range(-1, 2);
        isWalking = false;

        if (direction.x == 0)
        {
            animator.SetTrigger("Idle");
        }
        else
        {
            animator.SetTrigger("Walk");
        }
        //yield return new WaitForSeconds(10);
        //animator.SetTrigger("Idle");
    }
}
