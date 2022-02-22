using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using TMPro;

public class enemy_move : MonoBehaviour
{
    //Scripts
    public gun_shoot score;
    public HP HP;

    //Animator
    private Animator playerAnimator;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float attackRange;
    public bool playerInAttackRange;
    public float curHealth = 100;

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) AttackPlayer();

        transform.LookAt(player);  
    }

    private void Awake()
    { 
        HP = FindObjectOfType<HP>();
        score = FindObjectOfType<gun_shoot>();

        playerAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        playerAnimator.SetBool("Walk Forward", true);
    }

    private void AttackPlayer()
    {
        //Enemy stop moving while attacking
        agent.SetDestination(transform.position);
        playerAnimator.SetBool("Walk Forward", false);

        if (!alreadyAttacked)
        {
            //attackCode
            int randomAttackType = Random.Range(1, 3);
            playerAnimator.SetInteger("AttackType_int", randomAttackType);

            playerAnimator.SetTrigger("Smash Attack");
            playerAnimator.SetTrigger("Stab Attack");

            HP.currentHealth = HP.currentHealth - 10;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false; 
    }

    //Attack Range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
    }

    //Take Damage 
    public void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("bulet"))
        {
            playerAnimator.SetTrigger("Take Damage");
            score.score = score.score + 3;
            curHealth = curHealth-5;

            if (curHealth < 0)
            {
                curHealth = 0;
            }

            if (curHealth == 0)
            {
                score.score = score.score+100;
                Destroy(gameObject);
            }
        }

    }

}
