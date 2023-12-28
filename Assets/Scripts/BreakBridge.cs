using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBridge : MonoBehaviour
{
    [SerializeField] private GameObject bossHealthBar;
    [SerializeField] private GameObject bridgeRope;
    [SerializeField] private GameObject finalBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(bridgeRope);

            finalBoss.GetComponent<EnemyController>().enabled = true;

            bossHealthBar.SetActive(true);

            Destroy(gameObject);
        }
    }
}
