using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Timer timer;
    public TextMeshProUGUI timerText;

    private int coins;
    public TextMeshProUGUI coinsText;

    private int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        timer.StartTimer();
        coins = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = $"Time\n {timer.timeRemaining}";
        coinsText.text = $"x{coins}";
        scoreText.text = $"Mario\n {score}";
    }

    public void IncrementScore()
    {
        score++;
    }

    public void IncrementScore(int value)
    {
        score += value;
    }

    public void DecrementScore()
    {
        score--;
    }

    public void DecrementScore(int value)
    {
        score -= value;
    }
    
    public void IncrementCoins()
    {
        coins++;
    }

    public void IncrementCoins(int value)
    {
        coins += value;
    }

    public void DecrementCoins()
    {
        coins--;
    }

    public void DecrementCoins(int value)
    {
        coins -= value;
    }
}
