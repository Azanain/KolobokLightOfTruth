using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private Transform player;
    //private MobileContr mContr;
    private Rigidbody rb;
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = player.GetComponent<Rigidbody>();
      //  mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>();
    }
    private  void Update()
    {
        transform.position = player.transform.position;
        if(!RotateToNearTarget.enemyFound)
            if (rb.velocity.magnitude!=0)
            {
                transform.rotation = Quaternion.LookRotation(rb.velocity);
            }
                
    }
}
