using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    public TextMeshPro player1ScoreText;
    public TextMeshPro player2ScoreText;

    public Button start;
    public GameObject titleScreen;
    
    public GameObject ball;
    private BallController _ballController;
    private PaddleController lastHitBy;
    public GameObject powerUp;
    public TextMeshProUGUI powerUpText;

    private void Start()
    {
        _ballController = ball.GetComponent<BallController>();
        UpdateScoreText(0);
    }

    private void Update()
    {
        var ran = Random.value;
        switch (ran)
        {
            case > 0.0f and < 0.00005f:
                Instantiate(powerUp, new Vector3(Random.Range(-4, 4), Random.Range(-5, 7), 0), Quaternion.identity);
                break;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            titleScreen.SetActive(true);
            _ballController.gameObject.SetActive(false);
        }
    }

    public void UpdateLastHitBy(PaddleController player)
    {
        lastHitBy = player;
    }

    private void UpdateScoreText(int player)
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    public void IncrementPlayer1Score()
    {
        player1Score += 1;
        _ballController.ResetBall(1);
        UpdateScoreText(1);
        player1ScoreText.GetComponent<Animator>().Play("TextPop");
    }
    
    public void IncrementPlayer2Score()
    {
        player2Score += 1;
        _ballController.ResetBall(2);
        UpdateScoreText(2);
        player2ScoreText.GetComponent<Animator>().Play("TextPop");
    }

    public void StartButtonClicked()
    {
        start.GetComponent<Animator>().Play("StartClicked");
        StartCoroutine(WaitToPlay());
    }
    
    private IEnumerator WaitToPlay()
    {
        yield return new WaitForSeconds(0.9f);
        titleScreen.SetActive(false);
        _ballController.gameObject.SetActive(true);
        _ballController.ResetBall(2);
    }

    public void ApplyPowerUp()
    {
        if (Random.Range(0, 2) < 1)
        {
            ApplyBigPowerUp();
        }
        else
        {
            ApplySpeedPowerUp();
        }
        
    }

    private void ApplyBigPowerUp()
    {
        lastHitBy.transform.localScale = 1.1f * lastHitBy.transform.localScale;
    }

    private void ApplySpeedPowerUp()
    {
        lastHitBy.unitsPerSecond = lastHitBy.unitsPerSecond + 2;
    }
}
