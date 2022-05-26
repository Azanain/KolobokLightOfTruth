using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Open");
        Debug.Log("Open!");
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("Close");
        Debug.Log("Close!");
    }
}
