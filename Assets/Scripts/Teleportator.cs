using System.Collections;
using UnityEngine;

public class Teleportator : MonoBehaviour
{
    [SerializeField] private GameObject capsule;
    [SerializeField] private GameObject botPosition;
    [SerializeField] private float forcePlayer;
    [SerializeField] private int numberScene;
    private Transform player;
    private float posY;
    private void Start()
    {
        EventManager.CallCapsuleTeleportEvent += CapsuleCall;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void CapsuleCall()
    {
        EventManager.CanMove();
        transform.position = new Vector3(player.position.x, player.position.y + 4, player.position.z);
        capsule.transform.position = new Vector3(player.position.x, player.position.y + 15, player.position.z);
        capsule.SetActive(true);
        posY = player.position.y + 15;
        botPosition.transform.position = new Vector3(player.position.x, player.position.y + 4, player.position.z);
        botPosition.SetActive(true);
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        while (posY > 8)
        {
            capsule.transform.position = new Vector3(player.position.x, posY, player.position.z);
            posY -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        if (posY <= 8)
        {
            player.transform.position = Vector3.MoveTowards(player.position, new Vector3(player.position.x, player.position.y + 4, player.position.z), forcePlayer);
            EventManager.Jump(5);
            EventManager.TransferMoney();
            EventManager.SaveData();
            yield return new WaitForSeconds(1f);
            EventManager.LoadGameScene(numberScene);
        }
    }
    private void OnDestroy()
    {
        EventManager.CallCapsuleTeleportEvent -= CapsuleCall;
    }
}
