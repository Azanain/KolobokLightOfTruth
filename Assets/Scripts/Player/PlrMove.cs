using UnityEngine;

public class PlrMove : MonoBehaviour
{
    [Header("ќсновные параметры")]
    private float speed;
    private bool isJumping;
    [SerializeField] private float jumpForce;
    private float forceShieldOfFaith;
    private Vector3 moveInput;

    //—сылки на компоненты
    private Rigidbody rb;
    private MobileContr mContr;
    private RotateToNearTarget rotate;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
            isJumping = false;
    }
    private void Awake()
    {
        forceShieldOfFaith = 3;
        rotate = GetComponent<RotateToNearTarget>();
        EventManager.JumpEvent += Jump;
        speed = PlayerParametrs.Speed;
    }

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
       mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>();
    }

    private void FixedUpdate()
    {
        Move();
        rotate.RotateToNearEnemy();
    }

    /// <summary>
    /// метод перемещение персонажа
    /// </summary>
    private void Move()
    {
        if (!PlayerShoot.IsCheldActiv)
        {
            moveInput = new Vector3(-mContr.Horizontal() * speed, rb.velocity.y, -mContr.Vertical() * speed);
            rb.AddForce(moveInput);
        }
        //else
        //{
        //    moveInput = new Vector3(-mContr.Horizontal() * speed, rb.velocity.y, -mContr.Vertical() * speed * forceShieldOfFaith);
        //    rb.AddForce(moveInput);
        //    Debug.Log("Force");
        //}
    }
    /// <summary>
    /// метод прыжка персонажа
    /// </summary>
    private void Jump()
    {
        if (!isJumping)
        {
            Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
            rb.AddForce(jump);
            isJumping = true;
        }
    }
    private void OnDestroy()
    {
        EventManager.JumpEvent -= Jump;
    }
}
