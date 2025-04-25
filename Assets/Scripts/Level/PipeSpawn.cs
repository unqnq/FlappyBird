using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f;
    public float minY = -1f;
    public float maxY = 3f;
    public float pipeSpeed = 2f;
    public bool canSpawn = false;

    public void StartSpawnPipes()
    { 
        canSpawn = true;
        StartCoroutine(SpawnPipes());
    }

    private IEnumerator SpawnPipes()
    {
        while (canSpawn)
        {
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
            GameObject pipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
            pipe.GetComponent<PipeMove>().pipeSpeed = pipeSpeed;
             yield return new WaitForSeconds(spawnInterval);
        }
       
    }
}
