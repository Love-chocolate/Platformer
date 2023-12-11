using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject damageTrigger;

    private EnemyColliderDetection enemyColliderDetection;
    private GroundChecker groundChecker;
    private PlayerController playerController;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private float horizontal;

    void Start()
    {
        enemyColliderDetection = GetComponentInChildren<EnemyColliderDetection>();
        groundChecker = GetComponentInChildren<GroundChecker>();
        playerController = GetComponent<PlayerController>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector2(horizontal * speed, playerRigidbody.velocity.y);
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        Attack();
        Rotate();
        Run();
    }


    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && groundChecker.isGrounded)
        {
            animator.SetTrigger("isAttacking");
            
            playerController.enabled = false;

            StartCoroutine(WaitToMove());
        }
    }

    private IEnumerator WaitToMove()
    {
        yield return new WaitForSeconds(0.5f);

        playerController.enabled = true;
    }

    public void HitEnemy()
    {
        if(enemyColliderDetection.enemyHealth != null)
        {
            enemyColliderDetection.enemyHealth.DamageEnemy(enemyColliderDetection.damage);
        }
    }

}
