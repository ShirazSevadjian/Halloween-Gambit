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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(impactEffect, transform.position, Quaternion.identiy);
        Destroy(gameObject);
    }
}
