using System.Collections;
using UnityEngine;

public class PlrMove : MonoBehaviour
{
    //�������� ���������
    [SerializeField] private float speed;
    private float JumpCount;
    [SerializeField] private float jumpForce;

    //������ �� ����������
    private Rigidbody rb;
    private MobileContr mContr;

    void OnCollisionEnter(Collision other)
    {
        JumpCount = 0;
    }
    private void Awake()
    {
        EventManager.JumpEvent += Jump;
    }

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
       mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>();
    }

    private void FixedUpdate()
    {
         Move();
    }

    /// <summary>
    /// ����� ����������� ���������
    /// </summary>
    private void Move()
    {
        Vector3 moveInput = new Vector3(mContr.Horizontal() * speed, rb.velocity.y, mContr.Vertical() * speed);
        rb.AddForce(moveInput);
    }
    /// <summary>
    /// ����� ������ ���������
    /// </summary>
    private void Jump()
    {
        if (JumpCount < 1)
        {
            Vector3 jump = new Vector3(0.0f, jumpForce, 0.0f);
            rb.AddForce(jump);
            JumpCount++;
        }
    }
    /// <summary>
    /// ������� � ���������� �����
    /// </summary>
    private void RotateToNearEnemy()
    { 
        
    }
    private void OnDestroy()
    {
        EventManager.JumpEvent -= Jump;
    }
}
