using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    public ScoreHolder scoreHolder;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {  
            InstantiateBall();
        }
        
    }

    void InstantiateBall()
    {
        scoreHolder.IncreaseBallCount();
        Vector3 randomPosition = transform.position;
        randomPosition.x += Random.Range(-35, 35);
        GameObject ball = Instantiate(ballPrefab, randomPosition, Quaternion.identity);
    }

    public void SpawnMegaBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.transform.localScale = new Vector3(50, 50, 50);
        ball.AddComponent<MegaBall>();
    }
}
