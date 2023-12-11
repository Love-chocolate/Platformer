using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector] public bool isAttacking;

    [Header("Archer Settings")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float arrowPower;
    [SerializeField] private bool isArcher;

    [Header("Default Settings")]
    [SerializeField] private float distanceToDetectPlayer;
    [SerializeField] private float distanceToAttackPlayer;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float movementSpeed;

    private SpriteRenderer playerSpriteRenderer;
    private PlayerHealth playerHealth;
    private GameObject player;
    private Animator animator;

    private float enemyAndPlayerDistance;

    private void Start()
    {
        playerSpriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckDistance();

        LookAtPlayer();

        if(isArcher == false)
        {
            GoToPlayer();
        }

        if(isArcher == true)
        {
            StartShooting();
        }

        AttackPlayer();
    }

    private void GoToPlayer()
    {
        if (enemyAndPlayerDistance <= distanceToDetectPlayer && isAttacking == false)
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void AttackPlayer()
    {
        if (enemyAndPlayerDistance <= distanceToAttackPlayer && playerHealth.isAlive && isAttacking == false)
        {
            animator.SetTrigger("isAttacking");
            isAttacking = true;
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;

        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    private void CheckDistance()
    {
        enemyAndPlayerDistance = Vector2.Distance(transform.position, player.transform.position);
    }

    private void isNotAttacking()
    {
        isAttacking = false;
    }

    private void HitPlayer()
    {
        if(enemyAndPlayerDistance <= distanceToAttackPlayer)
        {
            playerHealth.DamagePlayer(damage);
        }
    }

    private void StartShooting()
    {
        if (enemyAndPlayerDistance > distanceToAttackPlayer && enemyAndPlayerDistance < distanceToDetectPlayer && playerHealth.isAlive)
        {
            animator.SetTrigger("isShooting");
        }
    }

    private void ShootArrow()
    {
        if (enemyAndPlayerDistance > distanceToAttackPlayer && enemyAndPlayerDistance < distanceToDetectPlayer && playerHealth.isAlive)
        {
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.transform.position - firePoint.position).normalized;
            directionToPlayer.y = 0f;
            directionToPlayer.z = 0f;

            arrow.transform.right = directionToPlayer;

            arrow.GetComponent<Rigidbody2D>().AddForce(directionToPlayer * arrowPower, ForceMode2D.Impulse);

        }
    }

}
