using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoreGui;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyDestroyed += EnemyOnEnemyDestroyed;
    }

    void EnemyOnEnemyDestroyed(int value)
    {
        score += value;
        scoreGui.text = "Score\n" + score.ToString("0000");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
