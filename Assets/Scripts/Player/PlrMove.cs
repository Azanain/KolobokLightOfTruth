using UnityEngine;

public class PlrMove : MonoBehaviour
{
    [Header("ќсновные параметры")]
    public float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float SpeedMultiplier;
    //  private float forceShieldOfFaith;
    private Vector3 moveInput;
    public GameObject frontPoint;
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
        EventManager.JumpEvent += Jump;
        EventManager.DiscardingEvent += Discarding;
        EventManager.DashEvent += Dash;

        //forceShieldOfFaith = 3;
        rotate = GetComponent<RotateToNearTarget>();
        speed = PlayerParametrs.Speed;
        mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (!ButtonRay.AimingLaser)
        {
            speed = PlayerParametrs.Speed;
            Move();
        }
        else
        {
            speed = 0;
            RotateAimingLaser();
        }

        rotate.RotateToNearEnemy();
    }
    private void RotateAimingLaser()
    {
        transform.rotation *= Quaternion.Euler(0, mContr.Horizontal(), 0);
    }

    /// <summary>
    /// метод перемещение персонажа
    /// </summary>
    private void Move()
    {
        if (!ReloadScills.Weapon1_1IsActive)
        {
            moveInput = new Vector3(-mContr.Horizontal() * speed, rb.velocity.y, -mContr.Vertical() * speed);
            rb.AddForce(moveInput* SpeedMultiplier);
        }
    }
    private void Discarding(float force)
    {
        var moveDiscard = (frontPoint.transform.position - transform.position).normalized;
        rb.AddForce(moveDiscard * force, ForceMode.Impulse);
    }
    private void Dash(float force)
    {
        var moveDiscard = (frontPoint.transform.position - transform.position).normalized;
        rb.AddForce(moveDiscard * -force, ForceMode.Impulse);
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
        EventManager.DiscardingEvent -= Discarding;
        EventManager.DashEvent -= Dash;
    }
}
