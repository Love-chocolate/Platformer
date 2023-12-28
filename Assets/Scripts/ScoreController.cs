using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score;

    [SerializeField] private Text scoreText;

    private void Start()
    {
        scoreText.text = $"Score: {score}";
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();
    }
}
