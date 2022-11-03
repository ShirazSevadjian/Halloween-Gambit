using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 4.5f;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundry")
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //Instantiate(impactEffect, transform.position, Quaternion.identiy);
        }

    }
}
