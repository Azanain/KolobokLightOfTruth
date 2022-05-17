using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float trackingSpeed = 2f;
    private Vector3 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (player)
        {
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, trackingSpeed * Time.deltaTime);
            transform.position = currentPosition;
            target = new Vector3(player.transform.position.x - 7f, transform.position.y, player.transform.position.z + 3f);
        }
    }
}
