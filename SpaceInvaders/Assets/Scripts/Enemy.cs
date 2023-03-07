using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDestroyed(int pointValue);
    public static event EnemyDestroyed OnEnemyDestroyed;

    public delegate void EnemyHitEnd();

    public static event EnemyHitEnd OnEnemyHitEnd;
    public int pointValue;
    public float shootChance = 0.1f;
    public GameObject bullet;

    private Camera Camera;
    private bool canShoot = false;

    private void Start()
    {
        Camera = FindObjectOfType<Camera>();
        Invoke(nameof(checkOnScreen), 1);
    }

    private void checkOnScreen()
    {
        var screenPos = Camera.WorldToScreenPoint(transform.position);
        var onScreen = screenPos.x > Screen.width * 0.05 && screenPos.x < Screen.width * 0.95;

        if (!onScreen)
        {
            OnEnemyHitEnd.Invoke();
        }
        
        Invoke(nameof(checkOnScreen), 1);
    }

    private void Update()
    {
        if (canShoot && (Random.value < shootChance))
        {
            var shot = Instantiate(bullet, transform.position, Quaternion.identity);

            Destroy(shot, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            OnEnemyDestroyed.Invoke(pointValue);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }

    }

    public void SetupLevelOne()
    {
        pointValue = 10;
    }

    public void SetupLevelTwo()
    {
        pointValue = 20;
    }

    public void SetupLevelThree()
    {
        pointValue = 40;
        canShoot = true;
    }
}
