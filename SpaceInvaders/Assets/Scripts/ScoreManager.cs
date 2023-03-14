using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreGui;
    public TextMeshProUGUI livesGUI;
    public TextMeshProUGUI highScoreGUI;
    
    public void UpdateScore(int score)
    {
        scoreGui.text = "Score\n" + score.ToString("0000");
    }

    public void UpdateLives(int lives)
    {
        livesGUI.text = "Lives\n" + lives.ToString("00");
    }

    public void UpdateHighScore(int score)
    {
        highScoreGUI.text = "High Score\n" + score.ToString("0000");
    }
}
