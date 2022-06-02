using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTerminalScript : MonoBehaviour
{
    [SerializeField] private GameObject terminal;
    public GameObject[] ObjectsToActivate = new GameObject[4];
    public GameObject[] ObjectsToDeActivate = new GameObject[4];

    private void Awake()
    {
        try
        {
            terminal = GameObject.FindGameObjectWithTag("terminal");
            terminal.SetActive(false);
        }
        catch
        {

        }

        foreach (GameObject _object in ObjectsToActivate)
        {
            try
            {
                _object.SetActive(false);
            }
            catch
            {

            };
        }

        foreach (GameObject _object in ObjectsToDeActivate)
        {
            try
            {
                _object.SetActive(true);
            }
            catch
            {

            };
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            try
            {
                terminal.SetActive(true);
            }
            catch
            {

            }

            foreach (GameObject _object in ObjectsToActivate)
            {
                try
                {
                    _object.SetActive(true);
                }
                catch
                {

                };
            }

            foreach (GameObject _object in ObjectsToDeActivate)
            {
                try
                {
                    _object.SetActive(false);
                }
                catch
                {

                };
            }
        }
    }
}
