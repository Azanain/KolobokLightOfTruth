using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Animator anim;
    private AudioSource sound;
    // Start
    // is called before the first frame update
    void Start()
    {
        try
        {
            anim = GetComponentInParent<Animator>();
            sound = GetComponent<AudioSource>();
            //Debug.Log("Script started!");
        }
        catch
        {
            Debug.Log("Some Error with animator!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        sound.Stop();
        anim.SetTrigger("Open");
        sound.Play();
        //Debug.Log("Open!");
    }

    private void OnTriggerExit(Collider other)
    {
        sound.Stop();
        anim.SetTrigger("Close");
        sound.Play();
        //Debug.Log("Close!");
    }
}
