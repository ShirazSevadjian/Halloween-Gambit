using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    public Transform firePosition;
    public Projectile2 projectile;
    public int cooldown = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Shoot());
        }
    }


    IEnumerator Shoot()
    {
        Instantiate(projectile, firePosition.position, firePosition.rotation);
        yield return new WaitForSeconds(cooldown);
    }
}
