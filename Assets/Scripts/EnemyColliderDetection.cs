using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderDetection : MonoBehaviour
{
    [HideInInspector] public int damage = 25;
    [HideInInspector] public EnemyHealth enemyHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyHealth = collision.GetComponent<EnemyHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyHealth = null;
        }
    }
}
