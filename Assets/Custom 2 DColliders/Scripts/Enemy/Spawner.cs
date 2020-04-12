using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject[] spawnPoints;

    [SerializeField] public GameObject Bear;

    [SerializeField] public float timeBetwenSpawn;
    void Start()
    {
        StartCoroutine(Spawners(timeBetwenSpawn));
    }

    // Update is called once per frame
    IEnumerator Spawners(float timeBetwenSpawn)
    {
        GameObject random = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
        Instantiate(Bear, random.transform.position, random.transform.rotation);

        yield return new WaitForSeconds(timeBetwenSpawn);
        StartCoroutine(Spawners(this.timeBetwenSpawn));
        
    }
}
