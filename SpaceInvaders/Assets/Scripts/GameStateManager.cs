using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public EnemyGroup enemyGroup;
    public GameObject BarricadePrefab;
    public GameObject playerPrefab;
    void Start()
    {
        enemyGroup.ResetEnemies();
        BuildBarricades();

        Player.OnPlayerKilled += OnPlayerKilled;
    }

    void StartGame()
    {
        enemyGroup.ResetEnemies();
    }

    void AdvanceRound()
    {
        enemyGroup.AdvanceRound();
        enemyGroup.ResetEnemies();
    }

    private void OnPlayerKilled()
    {
        enemyGroup.PauseEnemies();
        Invoke(nameof(PlayerRespawn), 3);
    }

    void PlayerRespawn()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
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
