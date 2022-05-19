using UnityEngine;


public class PlrMove : MonoBehaviour
{
    public FixedJoystick joystickLaser;

    [Header("ќсновные параметры")]
    public float speed;
    [SerializeField] private float jumpForce;
    //  private float forceShieldOfFaith;
    private Vector3 moveInput;
    public static bool isJumping { get; private set; }

    //—сылки на компоненты
    private Rigidbody rb;
    private MobileContr mContr;
    private RotateToNearTarget rotate;
    void OnCollisionEnter(Collision other)
    {
        isJumping = false;
    }
    private void Awake()
    {
        //forceShieldOfFaith = 3;
        joystickLaser = GameObject.FindGameObjectWithTag("JoystickLaser").GetComponent<FixedJoystick>();
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
            // moveInput = new Vector3(-mContr.Horizontal() * 0, rb.velocity.y, -mContr.Vertical() * 0);
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
    private void Jump(byte modeAction)
    {
        if (!isJumping)
        {
            Vector3 jump = new Vector3(0.0f, jumpForce * modeAction, 0.0f);
            rb.AddForce(jump);
            isJumping = true;
        }
    }
    private void OnDestroy()
    {
        EventManager.JumpEvent -= Jump;
    }
}
