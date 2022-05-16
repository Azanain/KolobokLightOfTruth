using System.Collections;
using UnityEngine;

public class PlrMove : MonoBehaviour
{
    [Header("Основные параметры")]
    [SerializeField] private float speed;
    private bool isJumping;
    [SerializeField] private float jumpForce;

    //Ссылки на компоненты
    private Rigidbody rb;
    private MobileContr mContr;

    [Header("Лазер")]
    [SerializeField] private GameObject laserWeapon;
    [SerializeField] private float radiusSphere;
    [SerializeField] private LayerMask layers;
    [SerializeField] private float speedRotation;
    private Transform nearest;
    private Vector2 range;

    public float offset;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
            isJumping = false;
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
        RotateToNearEnemy();
    }

    /// <summary>
    /// метод перемещение персонажа
    /// </summary>
    private void Move()
    {
        if (!PlayerShoot.IsCheldActiv)
        { 
            Vector3 moveInput = new Vector3(-mContr.Horizontal() * speed, rb.velocity.y, -mContr.Vertical() * speed);
            rb.AddForce(moveInput);
        }
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
    /// <summary>
    /// поворот к ближайшнму врагу
    /// </summary>
    private void RotateToNearEnemy()
    {
        if (PlayerShoot.IsLaserActiv)
        {
            Collider[] colls = Physics.OverlapSphere(transform.position, radiusSphere, layers);
            if (colls.Length > 0)
            {
                float dist = Mathf.Infinity;
                nearest = colls[0].transform;
                foreach (var foe in colls)
                {
                    range = foe.transform.position - transform.position;
                    float curDistance = range.sqrMagnitude;
                    if (curDistance < dist)
                    {
                        nearest = foe.transform;
                        dist = curDistance;
                        LookAtNearestEnemy(nearest);
                        Debug.Log(nearest.name);
                    }
                }
            }
        }
    }
    private void LookAtNearestEnemy(Transform nearest)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nearest.position + new Vector3(offset,0,0)), speedRotation * Time.deltaTime); 

        //Vector3 direction = nearest.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speedRotation * Time.deltaTime); ;
    }
    private void OnDestroy()
    {
        EventManager.JumpEvent -= Jump;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radiusSphere);
    }
}
