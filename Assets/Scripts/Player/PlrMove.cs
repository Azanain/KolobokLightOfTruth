using UnityEngine;

public class PlrMove : MonoBehaviour
{
    [Header("�������� ���������")]
    public float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float SpeedMultiplier;
    private Vector3 moveInput;
    [SerializeField] private GameObject frontPoint;
    [SerializeField] private GameObject body;
    public static bool isJumping { get; private set; }
    //public bool iPlayer1;

    //������ �� ����������
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
        
        speed = PlayerParametrs.Speed;
        mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>();
        rb = GetComponent<Rigidbody>();

        //if(!iPlayer1)
        Instantiate(body, transform.position, Quaternion.identity);
    }

    private void Start()
    {
        body = GameObject.FindGameObjectWithTag("PlayerBody");
        rotate = body.GetComponent<RotateToNearTarget>();
        //if (iPlayer1)
        //    rotate = GetComponent<RotateToNearTarget>();
        //else
        //    rotate = body.GetComponent<RotateToNearTarget>();
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
    /// ����� ����������� ���������
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
    /// ����� ������ ���������
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
