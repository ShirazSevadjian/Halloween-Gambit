using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss1 : MonoBehaviour
{
    public GameObject boss;
    public float speed = 10;
    public int timeOnScreen = 60;
    private float x_position;
    private GameObject bossInstance;
    public static int hitCounter = 0;
    public int spawnAfterTime = 60;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnAfterTime);
        x_position = Random.Range(-40, 40);
        Debug.Log("SPAWNED X=" + x_position);
        bossInstance = Instantiate(boss, new Vector3(x_position, 0.01f, 0), Quaternion.identity);
        yield return new WaitForSeconds(timeOnScreen);
        Destroy(bossInstance);

    }
}
