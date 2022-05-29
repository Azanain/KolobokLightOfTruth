using UnityEngine;
using UnityEngine.AI;

public class Gob01Follow : MonoBehaviour
{
    [SerializeField] private float agro; //радиус агро 
    [SerializeField] private float agro_K;
    [SerializeField] private float amount;  //количество зайцев
    [SerializeField] private float amount_K;  //количество зайцев
    private float radius = 20f;
    [SerializeField] private LayerMask layerEnemy;
    [HideInInspector] public float speed;
    private Transform player;
    private Transform enemyHare; 
    private NavMeshAgent meshAgent;
    private Animator animator;
    private int state;

    [Header("Attack")]
    [SerializeField] private int damage;
    [SerializeField] private Transform attackPosition;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackTimeout;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float attackDistance;
    private bool isAttacking;
    private float attackTimer = 0;

    private void Start()
    {    
        animator = transform.GetChild(0).GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyHare = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        meshAgent = GetComponent<NavMeshAgent>();
        FindingNumberOfEnemies();
    }

    private void Update()
    {
        state = ChangeState();
        State();      
    }

    /// <summary>
    /// метод нахождения количество врагов
    /// </summary>
    private void FindingNumberOfEnemies()
    {
        Collider[] hares = Physics.OverlapSphere(transform.position, radius, layerEnemy);
        foreach (var item in hares)
        {
            if (item.CompareTag("Enemy"))
            {
                //Debug.Log(item);
                amount++;
               // Debug.Log(amount);
            }
        }   
    }
    /// <summary>
    /// метод присвоения агро
    /// </summary>
    private void AgroAppropriations()
    {
        agro = agro_K+amount*amount_K;
    }

    /// <summary>
    /// метод изменения состояний действий
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
    /// метод действия при определонном состоянии
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
                PlayerPursuit();
                break;
            case 2:
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackTimeout)
                {
                    attackTimer = 0;
                    Attack();

                }
                break;
        }
    }

    /// <summary>
    /// метод преследование 
    /// </summary>
    private void PlayerPursuit()
    {
      //  AudioStart();
        meshAgent.destination = player.transform.position;
        transform.LookAt(player);
        isAttacking = false;
        animator.SetBool("Run", true);
    }

    /// <summary>
    /// метод атаки
    /// </summary>
    private void Attack()
    {
        speed = 0;
        transform.LookAt(player);
        int rnd = Mathf.RoundToInt(Random.Range(0.5f, 3.5f));

        //animator.SetBool("Run", false);
       // if (!isAttacking)
       // {
       //     isAttacking = true;
           
        //Debug.Log("Колобок, колобок, я тебя уничтожу!! "+ "Attack" + rnd.ToString());
        animator.SetTrigger("Attack"+rnd.ToString());
        OnAttack();
       // }

    }
    public void OnAttack()
    {
        Collider[] players = Physics.OverlapSphere(attackPosition.position, attackRadius, layer);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Player>().TakeDamage(damage);
        }
    }
    private void EndAttack()
    {
        isAttacking = false;
    }
    //private void AudioStart()
    //{
    //    if (gameObject.TryGetComponent<AudioSource>(out var audioSource))
    //    {
    //        audioSource.Play();
    //    }
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1,0.1f);
        Gizmos.DrawSphere(attackPosition.position, attackRadius);
    }

}

