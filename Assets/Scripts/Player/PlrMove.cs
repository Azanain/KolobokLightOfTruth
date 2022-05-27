using UnityEngine;

public class PlrMove : MonoBehaviour
{
    [Header("�������� ���������")]
    public float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float SpeedMultiplier;
    private Vector3 moveInput;
    private bool canMove;
    private GameObject frontPoint;
    [SerializeField] private GameObject body;
    public static bool isJumping { get; private set; }
    public static float moveVelosity { get; private set; }

    private PlayerAudio playerAudio;
    public Joystick joystick;

    //������ �� ����������
    private Rigidbody rb;
  //  private MobileContr mContr;
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
        EventManager.CanMoveEvent += CanMove;

        playerAudio = GetComponent<PlayerAudio>();
        // speed = PlayerParametrs.Speed;
        //mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        rb = GetComponent<Rigidbody>();
        Instantiate(body, transform.position, Quaternion.identity);
        canMove = true;
    }

    private void Start()
    {
        frontPoint = GameObject.FindGameObjectWithTag("FrontPoint");
        body = GameObject.FindGameObjectWithTag("PlayerBody");
        rotate = body.GetComponent<RotateToNearTarget>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
           speed = PlayerParametrs.Speed;
            Move();
        }
        else
        {
            //speed = 0;
            RotateAimingLaser();
        }
        rotate.RotateToNearEnemy();
        moveVelosity = rb.velocity.magnitude;
    }

    private void CanMove()
    {
        if (canMove)
            canMove = false;
        else
            canMove = true;     
    }

    private void RotateAimingLaser()
    {
        transform.rotation *= Quaternion.Euler(0, joystick.Horizontal, 0);
    }

    private void OnCollisionExit(Collision collision)
    {
        speed = 2f;
    }

    /// <summary>
    /// ����� ����������� ���������
    /// </summary>
    private void Move()
    {
        if (canMove)//(!ReloadScills.Weapon1_1IsActive)
        {
            moveInput = new Vector3(joystick.Vertical * speed, rb.velocity.y, -joystick.Horizontal * speed);
            rb.AddForce(moveInput * SpeedMultiplier);
            playerAudio.Move();
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
        rb.AddForce(moveDiscard * force, ForceMode.Impulse);
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
        EventManager.CanMoveEvent -= CanMove;
    }
}
