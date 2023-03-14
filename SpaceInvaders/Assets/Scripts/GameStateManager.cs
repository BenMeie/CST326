using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Windows;
using File = System.IO.File;
using Random = UnityEngine.Random;

public class GameStateManager : MonoBehaviour
{
    public ScoreManager ScoreManager;
    
    public EnemyGroup enemyGroup;
    public GameObject BarricadePrefab;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public AudioSource audioSource;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public string scoreFilePath = "Assets/scores.txt";
    public bool inGame;
    public ParticleSystem winningParticles;

    private int roundNumber;
    private int playerLives;
    private int score;
    private int highScore;
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        
        Player.OnPlayerKilled += OnPlayerKilled;
        Enemy.OnAllEnemiesKilled += AdvanceRound;
        Enemy.OnEnemyDestroyed += OnEnemyKilled;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (inGame && Random.Range(0, 20000) == 0)
        {
            SpawnUFO();
        }

        if (score > highScore && inGame && !winningParticles.isPlaying)
        {
            winningParticles.Play();
        }
    }

    public void LoadGameScene()
    {
        StartCoroutine(StartGame());
        inGame = true;
    }

    IEnumerator StartGame()
    {
        SceneManager.LoadScene("SpaceInvader", LoadSceneMode.Single);
        yield return new WaitForNextFrameUnit();
        ScoreManager = FindObjectOfType<ScoreManager>();
        enemyGroup = FindObjectOfType<EnemyGroup>();
        winningParticles = FindObjectOfType<ParticleSystem>();
        yield return new WaitForNextFrameUnit();
        enemyGroup.ResetEnemies();
        BuildBarricades();

        roundNumber = 0;
        playerLives = 3;
        score = 0;

        if (File.Exists(scoreFilePath))
        {
            var fileContent = File.ReadAllText(scoreFilePath);
            highScore = int.Parse(fileContent);
        }

        ScoreManager.UpdateLives(playerLives);
        ScoreManager.UpdateScore(score);
        ScoreManager.UpdateHighScore(highScore);

        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    void EndGame()
    {
        File.WriteAllText(scoreFilePath, highScore.ToString());
        Player.OnPlayerKilled -= OnPlayerKilled;
        Enemy.OnAllEnemiesKilled -= AdvanceRound;
        Enemy.OnEnemyDestroyed -= OnEnemyKilled;
        SceneManager.LoadScene("Credits");
        Invoke(nameof(ReturnToTitle), 5);
    }

    void ReturnToTitle()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("Menu");
    }

    void AdvanceRound()
    {
        roundNumber++;
        playerLives++;
        enemyGroup.AdvanceRound(roundNumber);
        enemyGroup.ResetEnemies();
    }

    private void OnPlayerKilled()
    {
        if (playerLives > 0)
        {
            playerLives--;
            ScoreManager.UpdateLives(playerLives);
            enemyGroup.PauseEnemies(3);
            Invoke(nameof(PlayerRespawn), 3);

            var bullets = FindObjectsByType<Bullet>(FindObjectsSortMode.InstanceID);
            foreach (var bullet in bullets)
            {
                Destroy(bullet.gameObject);
            }
        }
        else
        {
            EndGame();
        }
    }

    private void OnEnemyKilled(int value)
    {
        score += value;
        ScoreManager.UpdateScore(score);
    }

    void PlayerRespawn()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    void SpawnUFO()
    {
        var position = new Vector3(-5f, 4f, 0);
        Instantiate(enemyPrefab, position, Quaternion.identity).SendMessage("SetupLevelFour");
    }

    void BuildBarricades()
    {
        var position = transform.position + (Vector3.up * 0.5f);
        Instantiate(BarricadePrefab, position + Vector3.right * -5, Quaternion.identity);
        Instantiate(BarricadePrefab, position + Vector3.right * -2, Quaternion.identity);
        Instantiate(BarricadePrefab, position + Vector3.right * 2, Quaternion.identity);
        Instantiate(BarricadePrefab, position + Vector3.right * 5, Quaternion.identity);
    }
}
