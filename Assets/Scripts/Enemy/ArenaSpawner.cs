using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaSpawner : MonoBehaviour
{
 
    [SerializeField] private GameObject[] enemy; //массив врагов
    [SerializeField] private Transform[] spawnPoint; //массив точек дл€ спавна
    [SerializeField] private float startTimeBtwSpawn;
    [SerializeField] private float firstWaveStartTimeBtwSpawn;
    [SerializeField] private int firstWaveEnemiesCount;
    [SerializeField] private float waveFactorK;
    [SerializeField] private GameObject panelUI;
    private GameObject bossText;
    private Text timerText;
    private Text waveText;
    

    private float rand;
    private int randPosition;
    private float timeBtwSpawns;
    private int waveNumber=0;
    private int totalEnemiesInWave;
    private int totalMiniBossesInWave;
    private Vector3 spawnPointShift;


    private void Start()
    {
        timeBtwSpawns = firstWaveStartTimeBtwSpawn;
        panelUI.SetActive(true);
        waveText = panelUI.transform.GetChild(0).GetComponent<Text>();
        timerText = panelUI.transform.GetChild(1).GetComponent<Text>();
        bossText = panelUI.transform.GetChild(2).gameObject;
    }

    private void UpdateText()
    {
        waveText.text = "¬олна противников: " + waveNumber.ToString("##");
        if (waveNumber % 5 == 0)
        {
            bossText.SetActive(true);
        }
        else
        {
            bossText.SetActive(false);
        }
    }

    private void Update()
    {
        
        timerText.text = "—ледующа€ волна через: " + Mathf.RoundToInt(timeBtwSpawns).ToString("##");

        if (timeBtwSpawns <= 0)
        {
            int spawnedEnemies = 0;
            int spawnedMiniBosses = 0;
            int i=0;

            totalEnemiesInWave = firstWaveEnemiesCount + Mathf.RoundToInt(waveNumber * waveFactorK);
            totalMiniBossesInWave = Mathf.RoundToInt(waveNumber/5*2);


            while (spawnedEnemies <= totalEnemiesInWave)
            {
                rand = Random.Range(-0.5f, 0.5f);
                spawnPointShift = spawnPoint[i].transform.position;
                spawnPointShift.x = spawnPointShift.x + rand;
                spawnPointShift.z = spawnPointShift.z + rand;
                Instantiate(enemy[0], spawnPointShift, Quaternion.identity);
                i++;
                if (i == 4) i = 0;
                spawnedEnemies++;
            }

            if (waveNumber % 5 == 0&&waveNumber>0)
            {
                while (spawnedMiniBosses <= totalMiniBossesInWave)
                {
                    rand = Random.Range(-0.5f, 0.5f);
                    spawnPointShift = spawnPoint[i].transform.position;
                    spawnPointShift.x = spawnPointShift.x + rand;
                    spawnPointShift.z = spawnPointShift.z + rand;
                    Instantiate(enemy[1], spawnPointShift, Quaternion.identity);
                    i++;
                    if (i == 4) i = 0;
                    spawnedMiniBosses++;
                }
            }
                //EventManager.ChangeNumberEnemy(+1);
            timeBtwSpawns = startTimeBtwSpawn;
            waveNumber++;
            UpdateText();
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}

