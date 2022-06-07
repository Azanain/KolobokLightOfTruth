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
            EventManager.CanMove();
            Debug.Log("Push!");
            try
            {
                wallCollider.enabled = false;
            }
            catch
            {

            };
            var moveDiscard = new Vector3(0, 0, -1);
            rb.AddForce(moveDiscard * force , ForceMode.Force);
            Debug.Log("Push me!");
            EventManager.CanMove();
            //playerAudio.Jump();
        }
    }
}
