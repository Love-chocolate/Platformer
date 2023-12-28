using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private GameObject cameraCanvas;
    [SerializeField] private GameObject deathCanvas;

    public bool isAlive = true;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private int currentHeart;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void DamagePlayer(float damage)
    {
        if (isAlive == true)
        {
            if (hearts[currentHeart].fillAmount > 0)
            {
                hearts[currentHeart].fillAmount -= damage;
            }

            spriteRenderer.color = Color.red;

            CheckIsAlive();

            StartCoroutine(AfterDamage());
        }
    }

    private void CheckIsAlive()
    {
        if(hearts[currentHeart].fillAmount <= 0)
        {
            if(currentHeart + 1 < hearts.Length)
            {
                currentHeart++;
            }
            else
            {
                Death();
            }
        }
    }

    public void Death()
    {
        isAlive = false;

        animator.SetTrigger("isDead");

        Destroy(GetComponent<PlayerController>());
        Destroy(GetComponentInChildren<GroundChecker>());
    }

    private void ShowDeathCanvas()
    {
        cameraCanvas.SetActive(false);
        deathCanvas.SetActive(true);
    }

    private IEnumerator AfterDamage()
    {
        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = Color.white;
    }
}
