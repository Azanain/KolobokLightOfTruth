using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveJumper : MonoBehaviour
{
    public GameObject wall;
    private Collider wallCollider;
    public int force;
    private Rigidbody rb;
    public GameObject player;

    private void Awake()
    {

        rb = player.GetComponent<Rigidbody>();
        wallCollider = wall.GetComponent<MeshCollider>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Push!");
            wallCollider.enabled = false;
            var moveDiscard = new Vector3(0, 0, -1);
            rb.AddForce(moveDiscard * force , ForceMode.Impulse);
            Debug.Log("Push me!");
            //playerAudio.Jump();
        }
    }
}
