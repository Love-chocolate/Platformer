using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDeath : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;

    private bool canDamagePlayer;
    private bool canDamageEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !canDamagePlayer)
        {
            playerHealth = collision.GetComponent<PlayerHealth>();

            canDamagePlayer = true;

            StartCoroutine(DamagePlayer());
        }
        else if (collision.CompareTag("Enemy") && !canDamageEnemy)
        {
            enemyHealth = collision.GetComponent<EnemyHealth>();

            canDamageEnemy = true;

            StartCoroutine(DamageEnemy());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canDamagePlayer = false;
        }
        else if (collision.CompareTag("Enemy"))
        {
            canDamageEnemy = false;
        }
    }

    private IEnumerator DamagePlayer()
    {
        while (canDamagePlayer == true)
        {
            yield return new WaitForSeconds(0.5f);

            playerHealth.DamagePlayer(1f);
        }
    }

    private IEnumerator DamageEnemy()
    {
        while (canDamageEnemy == true)
        {
            yield return new WaitForSeconds(0.5f);

            enemyHealth.DamageEnemy(25);
        }
    }

}
