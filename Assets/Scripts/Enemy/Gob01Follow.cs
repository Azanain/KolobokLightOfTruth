using UnityEngine;
using UnityEngine.AI;

public class Gob01Follow : MonoBehaviour
{
    [SerializeField] private float agro; //������ ���� 
    [SerializeField] private float agro_K;
    [SerializeField] private float amount;  //���������� ������
    [SerializeField] private float amount_K;  //���������� ������
    private float radius = 20f;
    [SerializeField] private LayerMask layerEnemy;
    [HideInInspector] public float speed;
    private Transform player;
    //private Transform enemyHare; 
    private NavMeshAgent meshAgent;
    private Animator animator;
    private int state;
    private Enemy enemy;
    private EnemyAudio enemyAudio;

    [Header("Attack")]
    [SerializeField] private int damage;
    [SerializeField] private Transform attackPosition;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackTimeout;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float attackDistance;
    [HideInInspector] public bool isAttacking;
    private int rnd;
    //private bool isAttacking;
    private float attackTimer = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        enemyAudio = GetComponentInChildren<EnemyAudio>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //enemyHare = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        meshAgent = GetComponent<NavMeshAgent>();
        FindingNumberOfEnemies();
    }

    private void Update()
    {
        if (!enemy.IsDead)
        {
            state = ChangeState();
            State();
        }
    }

    /// <summary>
    /// ����� ���������� ���������� ������
    /// </summary>
    private void FindingNumberOfEnemies()
    {
        Collider[] hares = Physics.OverlapSphere(transform.position, radius, layerEnemy);
        foreach (var item in hares)
        {
            if (item.CompareTag("Enemy"))
            {
                amount++;
            }
        }   
    }
    /// <summary>
    /// ����� ���������� ����
    /// </summary>
    private void AgroAppropriations()
    {
        agro = agro_K+amount*amount_K;
    }

    /// <summary>
    /// ����� ��������� ��������� ��������
    /// </summary>
    /// <returns></returns>
    private int ChangeState()
    {
        if (player != null)
        {
            AgroAppropriations();
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < attackDistance)
            {
                return 2;
            }
            if (distance < agro)
            {
                return 1;
            }
        }
        return 0;
    }

    /// <summary>
    /// ����� �������� ��� ������������ ���������
    /// </summary>
    private void State()
    {
        switch (state)
        {
        case 0:
            animator.SetBool("Run", false);
            speed = 0;
            break;
        case 1:
                if(!isAttacking)
                    PlayerPursuit();
            break;
        case 2:
            animator.SetBool("Run", false);
            speed = 0;
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackTimeout)
            {
                attackTimer = 0;
                if(!isAttacking)
                    Attack();

            }
        break;
        }
    }

    /// <summary>
    /// ����� ������������� 
    /// </summary>
    private void PlayerPursuit()
    {
        meshAgent.destination = player.transform.position;
        transform.LookAt(player);
        animator.SetBool("Run", true);
    }

    /// <summary>
    /// ����� �����
    /// </summary>
    private void Attack()
    {
        isAttacking = true;
        speed = 0;
        transform.LookAt(player);
        rnd = Mathf.RoundToInt(Random.Range(0.5f, 3.5f));
        animator.SetTrigger("Attack"+rnd.ToString());
        //enemyAudio.SoundAttack(rnd);
    }
    /// <summary>
    /// �� ����� �������� �����, ����� ������ ���������� ���������� ��� ��������� �����
    /// </summary>
    public void OnAttack()
    {
        Collider[] players = Physics.OverlapSphere(attackPosition.position, attackRadius, layer);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Player>().TakeDamage(damage);
        }
        enemyAudio.SoundAttack(rnd);
    }
    public void StartAnimationDeath()
    {
        animator.SetTrigger("Death");
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1,0.1f);
        Gizmos.DrawSphere(attackPosition.position, attackRadius);
    }
}

