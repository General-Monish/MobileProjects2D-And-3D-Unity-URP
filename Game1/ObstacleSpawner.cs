using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obsPrefab;
    [SerializeField] float Delay;
    [SerializeField] float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", Delay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-1.7f, 1.7f), 5.22f, 0);
        Instantiate(obsPrefab, spawnPos, obsPrefab.transform.rotation);
    }

   public void StopSpawningEnemy()
    {
        CancelInvoke("SpawnEnemy");
    }
}
