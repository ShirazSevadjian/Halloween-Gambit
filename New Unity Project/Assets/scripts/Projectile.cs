using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 4.5f;
    public GameObject impactEffect;
    public GameObject ghost;
    private bool spawnGhost;
    private GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnGhost = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;

        if(spawnGhost)
        {
            Instantiate(ghost, player.transform.position, Quaternion.Euler(0f, 180f, 0f));
            spawnGhost = false;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            if(other.gameObject.tag != "Enemy")
            {
                spawnGhost = true;
                PlayerController.currentHealth -= 33;
            }


            if (other.gameObject.tag == "Enemy")
            {
                //Add random points between 1-3
                PlayerController.points += Random.Range(1, 3);
                //Destroy the projectile
                Destroy(gameObject);
                //Instantiate explosion effect
                Instantiate(impactEffect, transform.position, Quaternion.identity);
            }
            
        }

    }

  
}
