using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    private int score = 0;
    private int ballCount = 0;
    public TextMeshProUGUI scoreText;
    public BallSpawner BallSpawner;

    public void UpdateScore(int by)
    {
        score += by;
        scoreText.text = "Score: " + score;
    }

    public void IncreaseBallCount()
    {
        ballCount++;
        if (ballCount > 1000)
        {
            BallSpawner.SpawnMegaBall();
            ballCount = 0;
        }
    }
}
