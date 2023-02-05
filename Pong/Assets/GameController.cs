using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int Player1Score;
    public int Player2Score;
    public int TotalScore;
    public GameObject ball;
    private BallController ballController;

    private void Start()
    {
        ballController = ball.GetComponent<BallController>();
    }

    public int GetPlayer1Score()
    {
        return Player1Score;
    }

    public int GetPlayer2Score()
    {
        return Player2Score;
    }

    public void IncrementPlayer1Score()
    {
        Player1Score += 1;
        Debug.Log("Player 1 scored. Score is now " + Player1Score + " to " + Player2Score);
        ballController.ResetBall(1);
    }
    
    public void IncrementPlayer2Score()
    {
        Player2Score += 1;
        Debug.Log("Player 2 scored. Score is now " + Player2Score + " to " + Player1Score);
        ballController.ResetBall(2);
    }
}
