using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTerminalScript : MonoBehaviour
{
    [SerializeField] private GameObject terminal;
    public GameObject[] ObjectsToActivate;
    public GameObject[] ObjectsToDeActivate;
    public GameObject[] AnimationsToPlay;
    public GameObject[] AnimatorsToAdd;

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

            foreach (GameObject _anim in AnimationsToPlay)
            {
                try
                {
                    _anim.GetComponent<Animation>().Play();
                }
                catch
                {

                };
            }


            foreach (GameObject _anim in AnimationsToPlay)
            {
                try
                {
                    int btns = _anim.GetComponent<Animator>().GetInteger("BTNS");
                    _anim.GetComponent<Animator>().SetInteger("BTNS",btns++);
                }
                catch
                {

                };
            }
        }
    }
}
