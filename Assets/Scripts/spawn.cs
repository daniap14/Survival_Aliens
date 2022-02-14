using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(36, 44, 0);
    private Vector3 spawnPos2 = new Vector3(-17, 44, 0);

    private float repeatSpawn = 5f;
    private float startSpawn = 2f;

    public float max = 10;
    public float count = 1;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startSpawn, repeatSpawn);
    }

    
    public void SpawnObstacle()
    {
        if(count < max)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

            count++;
        }
        if (count < max)
        {
            Instantiate(obstaclePrefab, spawnPos2, obstaclePrefab.transform.rotation);

            count++;
        }

    }
}
