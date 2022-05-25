using System.Collections;
using UnityEngine;

public class Teleportator : MonoBehaviour
{
    [SerializeField] private GameObject capsule;
    private float positionCapsuleY;
    private Transform playerPosition;
    private Transform player;
    [SerializeField] private GameObject botPosition;
    [SerializeField] private Rigidbody rb;
    private void Start()
    {
        EventManager.CallCapsuleTeleportEvent += CapsuleCall;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void CapsuleCall()
    {
        EventManager.CanMove();
        playerPosition = player.transform;
        botPosition.transform.position = new Vector3(player.position.x, player.position.y +4, player.position.z);
        botPosition.SetActive(true);
        positionCapsuleY = playerPosition.position.y + 35f;
        capsule.transform.position = new Vector3(playerPosition.position.x, positionCapsuleY, playerPosition.position.z);
        capsule.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "botPosition")
        {
            rb.useGravity = false;
            Debug.Log("afafs");
        }
    }
    private void OnDestroy()
    {
        EventManager.CallCapsuleTeleportEvent -= CapsuleCall;
    }
}
