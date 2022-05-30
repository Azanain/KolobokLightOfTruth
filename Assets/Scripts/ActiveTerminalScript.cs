using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTerminalScript : MonoBehaviour
{
    [SerializeField] private GameObject terminal;

    private void Awake()
    {
        terminal = GameObject.FindGameObjectWithTag("terminal");
        terminal.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            terminal.SetActive(true);
        }
    }
}
