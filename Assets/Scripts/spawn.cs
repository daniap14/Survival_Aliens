using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawn : MonoBehaviour
{
    public TextMeshProUGUI text;

    public HP HP;

    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(36, 44, 0);
    private Vector3 spawnPos2 = new Vector3(-17, 44, 0);

    private float repeatSpawn = 5f;
    private float startSpawn = 2f;

    public float round = 1;
    public float max = 10;
    public float count = 1;

    public float kill = 0;

    void Start()
    {
        HP = FindObjectOfType<HP>();
        InvokeRepeating("SpawnObstacle", startSpawn, repeatSpawn);

        percistence_data.sharedInstance.scoreData = 0;
    }

    private void Update()
    {
        text.SetText("Ronda " + round);
    }

    
    public void SpawnObstacle()
    {
        if(count <= max)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

            count++;
        }
        if (count <= max)
        {
            Instantiate(obstaclePrefab, spawnPos2, obstaclePrefab.transform.rotation);

            count++;
        }

        if (max == kill)
        {
            kill = 0;
            count = 1;
            HP.currentHealth = 100;
            round++;
            max = max + round;
        }

    }
}
