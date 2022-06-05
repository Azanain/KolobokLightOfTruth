using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = player.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.position = player.transform.position;
        if (!RotateToNearTarget.enemyFound)
            //if (rb.velocity.magnitude != 0)
            //{
                transform.rotation = Quaternion.LookRotation(rb.velocity);
            //}
    }
}
