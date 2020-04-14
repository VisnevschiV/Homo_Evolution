using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject[] spawnPoints;

    [SerializeField] public GameObject Bear;

    [SerializeField] public float timeBetwenSpawn;
    private float _spawntime=0;
    [SerializeField] private int _maxNumberOfBears;
     private GameObject[] _numberOfBearsObTheMap;
    void Start()
    {
        
    }

    void Update()
    {
        _numberOfBearsObTheMap = GameObject.FindGameObjectsWithTag("enemy");
        if (_numberOfBearsObTheMap.Length < _maxNumberOfBears)
        {
           StartSpawn();
        }
    }

    public void StartSpawn()
    {
        if (_spawntime <Time.time)
        {
            _spawntime += Time.time+timeBetwenSpawn;
            StartCoroutine(Spawners(timeBetwenSpawn));
        }
    }

    // Update is called once per frame
    IEnumerator Spawners(float timeBetwenSpawn)
    {
        GameObject random = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
        Instantiate(Bear, random.transform.position, random.transform.rotation);

        yield return new WaitForSeconds(timeBetwenSpawn);
    }
}
