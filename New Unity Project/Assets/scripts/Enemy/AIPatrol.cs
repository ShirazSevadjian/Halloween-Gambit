using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float walkSpeed;
    private bool isWalking = false;
    private Vector3 direction = Vector3.zero;
    private Vector3 destination;
    public float patrolDistance = 2;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWalking)
        {
            StartCoroutine(changeDirection());
        }

        destination = transform.position + direction * patrolDistance;
        //transform.position += direction * walkSpeed * Time.deltaTime;
        if(transform.position.x > destination.x)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if(transform.position.x < destination.x)
        {
            transform.rotation = Quaternion.Euler(0, -270, 0);
        }
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime);
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
