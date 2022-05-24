using UnityEngine;

public class Teleportator : MonoBehaviour
{
    [SerializeField] private GameObject capsule;
    
    private Transform playerPosition;
    private GameObject player;
    private bool isCaused;
    private void Start()
    {
        EventManager.CallCapsuleTeleportEvent += CapsuleCall;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void CapsuleCall()
    {
        if (!isCaused)
        { 
            playerPosition = player.transform;
            float positionCapsuleY = playerPosition.transform.position.y + 12f;
            capsule.transform.position = new Vector3(playerPosition.transform.position.x, positionCapsuleY, playerPosition.transform.position.z);
            capsule.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        EventManager.CallCapsuleTeleportEvent -= CapsuleCall;
    }
}
