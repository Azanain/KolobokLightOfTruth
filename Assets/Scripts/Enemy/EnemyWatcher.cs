using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWatcher : MonoBehaviour
{
    private int numberEnemy;
    private void Awake()
    {
        EventManager.ChangeNumberEnemyEvent += ChangeNumberEnemy;
    }
    private void Start()
    {
        numberEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    private void ChangeNumberEnemy(int number)
    {
        numberEnemy += number;
        CheckNumberEnemies();
    }
    private void CheckNumberEnemies()
    {
        if (numberEnemy >= 0)
        {
            EventManager.Win(true);
        }
    }

    private void OnDestroy()
    {
        EventManager.ChangeNumberEnemyEvent += ChangeNumberEnemy;
    }
}
