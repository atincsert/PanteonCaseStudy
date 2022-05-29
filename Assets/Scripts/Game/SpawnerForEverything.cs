using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerForEverything : MonoBehaviour
{
    [SerializeField] GameObject spawnable;
    [SerializeField] GameObject[] spawnableObstacles;
 
    private static readonly float maxRangeXForSpawnables = 225f;

    private void Start()
    {

        for (int i = 0; i < 11; i++)
        {
            float randomX = Random.Range(-maxRangeXForSpawnables, maxRangeXForSpawnables);
            float randomY = this.transform.position.y;
            float randomZ = this.transform.position.z;

            Vector3 spawnPos = new Vector3(randomX, randomY, randomZ);
            Instantiate(spawnable, spawnPos, Quaternion.identity);           
        }

        foreach (GameObject spawnableObstacle in spawnableObstacles)
        {
            for (int i = 0; i < 31; i++)
            {
                float randomX = Random.Range(-maxRangeXForSpawnables, maxRangeXForSpawnables);
                float randomY = this.transform.position.y;
                float randomZ = this.transform.position.z;

                Vector3 spawnPos = new Vector3(randomX, randomY, randomZ);
                Instantiate(spawnableObstacle, spawnPos, Quaternion.identity);
            }
        }
    }

    private void Update()
    {
    }
}
