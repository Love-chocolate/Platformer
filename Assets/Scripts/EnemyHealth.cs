using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("FinalBoss Setting")]
    [SerializeField] private GameObject completedGamePanel;
    [SerializeField] private Image bossHealthBar;
    [SerializeField] private bool isFinalBoss;

    [Header("Default Settings")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int scoreToAdd;

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

            if (isFinalBoss)
            {
                bossHealthBar.fillAmount -= (float)damage / maxHealth;
            }

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

    public void Death()
    {
        animator.SetTrigger("isDead");

        enemyController.enabled = false;

        isAlive = false;

        GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreController>().AddScore(scoreToAdd);
    }

    private void DeleteEnemy()
    {
        Destroy(gameObject);

        if (isFinalBoss)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;

            completedGamePanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    private IEnumerator AfterDamage()
    {
        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = Color.white;
    }
}
