using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMainTerminal : MonoBehaviour
{
    [SerializeField] private GameObject panelMainTerminal;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            panelMainTerminal.SetActive(true);
        }
    }
}
