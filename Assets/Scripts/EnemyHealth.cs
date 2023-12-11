using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private EnemyController enemyController;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isAlive = true;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        enemyController = GetComponent<EnemyController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void DamageEnemy(int damage)
    {
        if (isAlive == true)
        {
            currentHealth -= damage;

            spriteRenderer.color = Color.red;

            CheckIsAlive();

            StartCoroutine(AfterDamage());
        }
    }

    private void CheckIsAlive()
    {
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        animator.SetTrigger("isDead");

        enemyController.enabled = false;

        isAlive = false;
    }

    public void DeleteEnemy()
    {
        Destroy(gameObject);
    }

    private IEnumerator AfterDamage()
    {
        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = Color.white;
    }
}
