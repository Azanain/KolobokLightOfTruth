using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSpawn : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("SpawnerEnemy");
        spawner.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            spawner.SetActive(true); 
        }
    }
}
