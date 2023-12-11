using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] heart;
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
            if (heart[currentHeart].fillAmount > 0)
            {
                heart[currentHeart].fillAmount -= damage;
            }

            spriteRenderer.color = Color.red;

            CheckIsAlive();

            StartCoroutine(AfterDamage());
        }
    }

    private void CheckIsAlive()
    {
        if(heart[currentHeart].fillAmount <= 0)
        {
            if(currentHeart + 1 < heart.Length)
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

        animator.SetBool("isAlive", false);

        GetComponent<PlayerController>().enabled = false;

        //spriteRenderer.color = Color.red;

        //StartCoroutine(WaitToShowDeathCanvas());
    }

    private void ShowDeathCanvas()
    {
        cameraCanvas.SetActive(false);
        deathCanvas.SetActive(true);
    }

    /*private IEnumerator WaitToShowDeathCanvas()
    {
        yield return new WaitForSeconds(1.5f);

        cameraCanvas.SetActive(false);
        deathCanvas.SetActive(true);
    }*/

    private IEnumerator AfterDamage()
    {
        yield return new WaitForSeconds(0.2f);

        spriteRenderer.color = Color.white;
    }
}
