using UnityEngine;

public class PlrMoveALTR : MonoBehaviour
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
    public MobileContr mContr;
    private RotateToNearTarget rotate;

    void OnCollisionEnter(Collision other)
    {
        isJumping = false;
        if (other.gameObject.CompareTag("Ground"))
        {
            //playerAudio.Landing();
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            playerAudio.HitWall();
        }
    }

    private void Awake()
    {
        EventManager.JumpEvent += Jump;
        EventManager.DiscardingEvent += Discarding;
        EventManager.DashEvent += Dash;
        EventManager.CanMoveEvent += CanMove;

        playerAudio = GetComponentInChildren<PlayerAudio>();
        // speed = PlayerParametrs.Speed;
        mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>();
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
           // RotateAimingLaser();
        }
        rotate.RotateToNearEnemy();
        moveVelosity = rb.velocity.magnitude;
    }
    /// <summary>
    /// ������ �������� ���������
    /// </summary>
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

    //private void OnCollisionExit(Collision collision)
    /// <summary>
    /// ������� ��������� � ������ ������������ �������
    /// </summary>
    //private void RotateAimingLaser()
    //{
    //    speed = 2f;
    //}

    /// <summary>
    /// ����� ����������� ���������
    /// </summary>
    private void Move()
    {
        if (canMove)
        {
            // moveInput = new Vector3(-mContr.Horizontal() * speed, rb.velocity.y, -mContr.Vertical() * speed);

            //moveInput = new Vector3(-mContr.Horizontal * speed, 0, -mContr.Vertical * speed);
            moveInput = new Vector3(-mContr.Horizontal() * speed, 0, -mContr.Vertical() * speed);
            //moveInput = Quaternion.EulerAngles();
            rb.AddForce(moveInput* SpeedMultiplier);

            //Vector3.AngleBetween( rb.velocity

            playerAudio.Move();
        }
    }
    /// <summary>
    /// ����� �����������
    /// </summary>
    /// <param name="force"></param>
    private void Discarding(float force)
    {
        var moveDiscard = (frontPoint.transform.position - transform.position).normalized;
        rb.AddForce(moveDiscard * force, ForceMode.Impulse);
        playerAudio.Jump();
    }
    private void Dash(float force)
    {
        var moveDiscard = (frontPoint.transform.position - transform.position).normalized;
        rb.AddForce(moveDiscard * force * PlayerParametrs.DashRangeWeapon1, ForceMode.Impulse);
        playerAudio.Jump();
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
            playerAudio.Jump();
        }
    }
    /// <summary>
    /// ������� �� �������
    /// </summary>
    private void OnDestroy()
    { 
        EventManager.JumpEvent -= Jump;
        EventManager.DiscardingEvent -= Discarding;
        EventManager.DashEvent -= Dash;
        EventManager.CanMoveEvent -= CanMove;
    }
}