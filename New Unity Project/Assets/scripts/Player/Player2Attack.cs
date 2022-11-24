using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    public Transform firePosition;
    public Projectile projectile;
    public float cooldown = 1;
    public float firingTimer = 1;
    private bool specialMode = false;
    public GameObject lightObject;
    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = lightObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            firingTimer -= Time.deltaTime;
            if (firingTimer < 0)
            {
                ShootProjectile();
                firingTimer += cooldown;
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Shoot());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(SpecialMode());

        }
    }

    private void ShootProjectile()
    {
        Instantiate(projectile, firePosition.position, firePosition.rotation);
    }

    IEnumerator Shoot()
    {
        Instantiate(projectile, firePosition.position, firePosition.rotation);
        yield return new WaitForSeconds(cooldown);
    }

    IEnumerator SpecialMode()
    {
        //SpawnEnemies enemies = new SpawnEnemies();
        cooldown = 0.2f;
        light.color = Color.red;
        yield return new WaitForSeconds(3);
        cooldown = 1f;
        light.color = Color.white;
    }
}
