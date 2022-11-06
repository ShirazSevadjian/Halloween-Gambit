using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public int enemyCount = 5;
    public GameObject enemy;

    private float x_position;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        while(enemyCount != 0)
        {
            x_position = Random.Range(-60, 60);
            Instantiate(enemy, new Vector3(x_position, 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount -= 1;
        }
    }
}
