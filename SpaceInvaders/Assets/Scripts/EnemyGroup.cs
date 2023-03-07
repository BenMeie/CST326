using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGroup : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float direction;
    public float speed;
    public Vector3 initialPosition = new Vector3(-3.5f, 1, 0);

    private bool paused = false;
    void Start()
    {
        Enemy.OnEnemyDestroyed += IncreaseSpeed;
        Enemy.OnEnemyHitEnd += OnEnemyHitEnd;
    }

    public void AdvanceRound()
    {
        initialPosition += new Vector3(0, -0.25f, 0);
        speed -= 0.02f;
    }

    public void ResetEnemies()
    {
        transform.position = initialPosition;
        InstantiateEnemies(initialPosition);
        Invoke(nameof(Movement), 1);
    }

    void IncreaseSpeed(int unused)
    {
        speed -= 0.01f;
        speed = Math.Clamp(speed, 0, 1);
    }

    public void PauseEnemies()
    {
        paused = true;
        Invoke(nameof(unPauseEnemies), 3);
    }

    void unPauseEnemies()
    {
        paused = false;
        Movement();
    }

    void OnEnemyHitEnd()
    {
        direction *= -1;
        transform.position += new Vector3(0, -0.05f, 0);
    }

    void Movement()
    {
        if (paused) return;
        transform.position += new Vector3(direction, 0, 0);
        Invoke(nameof(Movement), speed);
    }

    void InstantiateEnemies(Vector3 root)
    {
        
        var Row5 = Instantiate(new GameObject("Row5"),root + Vector3.up * 1.25f, Quaternion.identity, transform);
        Instantiate(EnemyPrefab, root + Vector3.up * 3.75f, Quaternion.identity, Row5.transform).SendMessage("SetupLevelThree");
        Instantiate(EnemyPrefab, root + Vector3.right * 1.25f + Vector3.up * 3.75f, Quaternion.identity, Row5.transform).SendMessage("SetupLevelThree");
        Instantiate(EnemyPrefab, root + Vector3.right * -1.25f + Vector3.up * 3.75f, Quaternion.identity, Row5.transform).SendMessage("SetupLevelThree");
        Instantiate(EnemyPrefab, root + Vector3.right * 2.5f + Vector3.up * 3.75f, Quaternion.identity, Row5.transform).SendMessage("SetupLevelThree");
        Instantiate(EnemyPrefab, root + Vector3.right * -2.5f + Vector3.up * 3.75f, Quaternion.identity, Row5.transform).SendMessage("SetupLevelThree");
        Instantiate(EnemyPrefab, root + Vector3.right * 3.75f + Vector3.up * 3.75f, Quaternion.identity, Row5.transform).SendMessage("SetupLevelThree");
        Instantiate(EnemyPrefab, root + Vector3.right * -3.75f + Vector3.up * 3.75f, Quaternion.identity, Row5.transform).SendMessage("SetupLevelThree");
        Instantiate(EnemyPrefab, root + Vector3.right * 5f + Vector3.up * 3.75f, Quaternion.identity, Row5.transform).SendMessage("SetupLevelThree");
        Instantiate(EnemyPrefab, root + Vector3.right * -5f + Vector3.up * 3.75f, Quaternion.identity, Row5.transform).SendMessage("SetupLevelThree");
        
        var Row4 = Instantiate(new GameObject("Row4"),root + Vector3.up * 1.25f, Quaternion.identity, transform);
        Instantiate(EnemyPrefab, root + Vector3.up * 2.5f, Quaternion.identity, Row4.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * 1.25f + Vector3.up * 2.5f, Quaternion.identity, Row4.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * -1.25f + Vector3.up * 2.5f, Quaternion.identity, Row4.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * 2.5f + Vector3.up * 2.5f, Quaternion.identity, Row4.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * -2.5f + Vector3.up * 2.5f, Quaternion.identity, Row4.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * 3.75f + Vector3.up * 2.5f, Quaternion.identity, Row4.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * -3.75f + Vector3.up * 2.5f, Quaternion.identity, Row4.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * 5f + Vector3.up * 2.5f, Quaternion.identity, Row4.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * -5f + Vector3.up * 2.5f, Quaternion.identity, Row4.transform).SendMessage("SetupLevelTwo");
        
        var Row3 = Instantiate(new GameObject("Row3"),root + Vector3.up * 1.25f, Quaternion.identity, transform);
        Instantiate(EnemyPrefab, root + Vector3.up * 1.25f, Quaternion.identity, Row3.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * 1.25f + Vector3.up * 1.25f, Quaternion.identity, Row3.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * -1.25f + Vector3.up * 1.25f, Quaternion.identity, Row3.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * 2.5f + Vector3.up * 1.25f, Quaternion.identity, Row3.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * -2.5f + Vector3.up * 1.25f, Quaternion.identity, Row3.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * 3.75f + Vector3.up * 1.25f, Quaternion.identity, Row3.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * -3.75f + Vector3.up * 1.25f, Quaternion.identity, Row3.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * 5f + Vector3.up * 1.25f, Quaternion.identity, Row3.transform).SendMessage("SetupLevelTwo");
        Instantiate(EnemyPrefab, root + Vector3.right * -5f + Vector3.up * 1.25f, Quaternion.identity, Row3.transform).SendMessage("SetupLevelTwo");
        
        var Row2 = Instantiate(new GameObject("Row2"),root, Quaternion.identity, transform);
        Instantiate(EnemyPrefab, root, Quaternion.identity, Row2.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * 1.25f, Quaternion.identity, Row2.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * -1.25f, Quaternion.identity, Row2.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * 2.5f, Quaternion.identity, Row2.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * -2.5f, Quaternion.identity, Row2.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * 3.75f, Quaternion.identity, Row2.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * -3.75f, Quaternion.identity, Row2.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * 5f, Quaternion.identity, Row2.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * -5f, Quaternion.identity, Row2.transform).SendMessage("SetupLevelOne");
        
        var Row1 = Instantiate(new GameObject("Row1"),root + Vector3.up * -1.25f, Quaternion.identity, transform);
        Instantiate(EnemyPrefab, root + Vector3.up * -1.25f, Quaternion.identity, Row1.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * 1.25f + Vector3.up * -1.25f, Quaternion.identity, Row1.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * -1.25f + Vector3.up * -1.25f, Quaternion.identity, Row1.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * 2.5f + Vector3.up * -1.25f, Quaternion.identity, Row1.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * -2.5f + Vector3.up * -1.25f, Quaternion.identity, Row1.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * 3.75f + Vector3.up * -1.25f, Quaternion.identity, Row1.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * -3.75f + Vector3.up * -1.25f, Quaternion.identity, Row1.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * 5f + Vector3.up * -1.25f, Quaternion.identity, Row1.transform).SendMessage("SetupLevelOne");
        Instantiate(EnemyPrefab, root + Vector3.right * -5f + Vector3.up * -1.25f, Quaternion.identity, Row1.transform).SendMessage("SetupLevelOne");
    }
}
