using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Animator anim;
    private AudioSource sound;
    [SerializeField] private bool doorEnabled ;
    [SerializeField] private AudioClip soundDoorOpen;
    [SerializeField] private AudioClip soundDoorClose;
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
        if (doorEnabled)
        {
            sound.Stop();
            sound.clip = soundDoorOpen;
            anim.SetTrigger("Open");
            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (doorEnabled)
        {
            sound.Stop();
            sound.clip = soundDoorOpen;
            anim.SetTrigger("Close");
            sound.Play();
        }
    }
}
