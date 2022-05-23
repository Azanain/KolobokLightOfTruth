using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gob01Follow : MonoBehaviour
{
    [SerializeField] private float paramDistan;
    public float speed;
    private Transform player;
    private NavMeshAgent meshAgent;
    private Animator animator;
    private int state;

    [Header("Attack")]
    [SerializeField] private int damage;
    [SerializeField] private Transform attackPosition;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float attackDistance;
    private bool isAttacking;

    private void Start()
    {    
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        meshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        state = ChangeState();
        State();
    }

    /// <summary>
    /// метод изменения состояний действий
    /// </summary>
    /// <returns></returns>
    private int ChangeState()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < attackDistance)
            {
                return 2;
            }
            if (distance < paramDistan)
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
               // animator.SetBool("Run", false);
                speed = 0;
                break;
            case 1:
                PlayerPursuit();
                break;
            case 2:
                Attack();
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
        //animator.SetBool("Run", true);
    }

    /// <summary>
    /// метод атаки
    /// </summary>
    private void Attack()
    {
        speed = 0;
        transform.LookAt(player);
        Debug.Log("Колобок, колобок, я тебя уничтожу!!");
        //animator.SetBool("Run", false);
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
        }
       
    }
    public void OnAttack()
    {
        Collider[] players = Physics.OverlapSphere(attackPosition.position, attackRadius, layer);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Player>().TakeDamage(damage);
            Debug.Log(players[i]);
            Debug.Log(damage);
        }
    }
    private void EndAttack()
    {
        isAttacking = true;
    }
    //private void AudioStart()
    //{
    //    if (gameObject.TryGetComponent<AudioSource>(out var audioSource))
    //    {
    //        audioSource.Play();
    //    }
    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawSphere(attackPosition.position, attackRadius);
    //}
}
