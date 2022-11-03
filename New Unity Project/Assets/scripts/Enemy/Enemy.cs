using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public float walkRange = 10;
    public Animator animator;
    public float walkSpeed = 4;
    public float runSpeed = 8;

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
            if (distanceBetweenTarget < walkRange)
            {
                currentState = "WalkState";
            }
        }
        else if(currentState == "WalkState")
        {
            animator.SetTrigger("Walk");

            //Move Left
            if (target.position.x > transform.position.x)
            {
                transform.Translate(-transform.right * walkSpeed * Time.deltaTime);
                //transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            //Move Right
            else
            {
                transform.Translate(transform.right * walkSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }

            if(distanceBetweenTarget < chaseRange)
            {
                currentState = "RunState";
            }
        }
        else if (currentState == "RunState")
        {
            animator.SetTrigger("Chase");

            //Move Left
            if(target.position.x > transform.position.x)
            {
                transform.Translate(-transform.right * runSpeed * Time.deltaTime);
                //transform.rotation = Quaternion.identity;
            }
            //Move Right
            else
            {
                transform.Translate(transform.right * runSpeed * Time.deltaTime);
                //transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            if(distanceBetweenTarget > chaseRange)
            {
                Debug.Log("Inside condition");
                currentState = "WalkState";
            }
        }
    }
}
