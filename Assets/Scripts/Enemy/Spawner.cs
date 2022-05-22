using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy; //массив врагов
    [SerializeField] private Transform[] spawnPoint; //массив точек для спавна
    [SerializeField] private float startTimeBtwSpawn;

    private int rand;
    private int randPosition;
    private float timeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawn;
    }

    private void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, enemy.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemy[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
