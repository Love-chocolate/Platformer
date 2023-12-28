using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject completedLevelPopUp;
    [SerializeField] private Text scoreCountText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().enabled = false;

            scoreCountText.text = collision.GetComponent<ScoreController>().score.ToString();

            completedLevelPopUp.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}
