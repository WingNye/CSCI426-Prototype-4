using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject box;

    [SerializeField] 
    private float swarmInterval = 3.5f;

    [SerializeField] 
    private GameObject biggerbox;

    [SerializeField] 
    private float bigswarmInterval = 5f;

    void Start() 
    {
        StartCoroutine(spawnEnemy(swarmInterval, box));
        StartCoroutine(spawnEnemy(bigswarmInterval, biggerbox));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-9f, 9), Random.Range(-4f, 4), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}

