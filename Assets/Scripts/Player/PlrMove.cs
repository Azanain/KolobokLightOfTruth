using UnityEngine;

public class PlrMove : MonoBehaviour
{
    [Header("Основные параметры")]
    public float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float SpeedMultiplier;
    private Vector3 moveInput;
    private bool canMove;
    private GameObject frontPoint;
    [SerializeField] private GameObject body;
    public static bool isJumping { get; private set; }
    public static float moveVelosity { get; private set; }

    //Ссылки на компоненты
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
        EventManager.CanMoveEvent += CanMove;
        
        speed = PlayerParametrs.Speed;
        mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>();
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
    /// <summary>
    /// запрет движения персонажа
    /// </summary>
    private void CanMove()
    {
        if (canMove)
            canMove = false;
        else
            canMove = true;
           
    }
    /// <summary>
    /// поворот персонажа в режиме прицеливания лазером
    /// </summary>
    private void RotateAimingLaser()
    {
        transform.rotation *= Quaternion.Euler(0, mContr.Horizontal(), 0);
    }
    /// <summary>
    /// метод перемещение персонажа
    /// </summary>
    private void Move()
    {
        if (canMove)
        {
            moveInput = new Vector3(-mContr.Horizontal() * speed, rb.velocity.y, -mContr.Vertical() * speed);
            rb.AddForce(moveInput* SpeedMultiplier * PlayerParametrs.SpeedWeapon1);
        }
    }
    /// <summary>
    /// метод откидывания
    /// </summary>
    /// <param name="force"></param>
    private void Discarding(float force)
    {
        var moveDiscard = (frontPoint.transform.position - transform.position).normalized;
        rb.AddForce(moveDiscard * force, ForceMode.Impulse);
    }
    /// <summary>
    /// метод рывка
    /// </summary>
    /// <param name="force"></param>
    private void Dash(float force)
    {
        var moveDiscard = (frontPoint.transform.position - transform.position).normalized;
        rb.AddForce(moveDiscard * force * PlayerParametrs.DashRangeWeapon1, ForceMode.Impulse);
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
    /// <summary>
    /// отписка от евентов
    /// </summary>
    private void OnDestroy()
    {
        EventManager.JumpEvent -= Jump;
        EventManager.DiscardingEvent -= Discarding;
        EventManager.DashEvent -= Dash;
        EventManager.CanMoveEvent -= CanMove;
    }
}
