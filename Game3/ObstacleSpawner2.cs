using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner2 : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclesList = new List<GameObject>();
    Vector3 spawnPos;
    [SerializeField] float spawnRate;
    // Start is called before the first frame update

    void Start()
    {
        spawnPos=transform.position;
        StartCoroutine("SpawnObstaclesCouroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstaclesCouroutine()
    {
        while (true)
        {
            Spawn();
            GM2.instance.UpdateScore();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void Spawn()
    {
        int randomObstacle = Random.Range(0, obstaclesList.Count);
        int randomUpDownSpawn=Random.Range(0, 2); // 0 = top , 1 = bottom 
        spawnPos = transform.position;

        if(randomUpDownSpawn < 1)
        {
            Instantiate(obstaclesList[randomObstacle], spawnPos, transform.rotation);
        }
        else
        {
            spawnPos.y= -transform.position.y;

            if(randomObstacle == 1)
            {
                spawnPos.x += 1;
            }
            else if(randomObstacle == 2)
            {
                spawnPos.x += 2;
            }
            /*
            GameObject obs = Instantiate(obstaclesList[randomObstacle], spawnPos, transform.rotation);
            obs.transform.eulerAngles = new Vector3(0, 0, 180); // making them rotate 180 degree when spawn at bottom*/

            GameObject obs = Instantiate(obstaclesList[randomObstacle], spawnPos, transform.rotation);
            
            // instead of rotating the sprite we flipped it without affecting the movement
            obs.transform.localScale = new Vector3(obs.transform.localScale.x, -obs.transform.localScale.y, obs.transform.localScale.z);


        }

    }
}
