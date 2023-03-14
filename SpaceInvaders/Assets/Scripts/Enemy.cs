using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDestroyed(int pointValue);
    public static event EnemyDestroyed OnEnemyDestroyed;
    public delegate void AllEnemiesKilled();
    public static event AllEnemiesKilled OnAllEnemiesKilled;
    
    public int pointValue;
    public float shootChance = 0.1f;
    public GameObject bullet;
    public EnemyGroup enemyGroup;
    public int enemyType;
    public bool inUI;
    public GameObject explosionPrefab;
    
    private Animator animator;
    private Camera Camera;
    private bool canShoot = false;
    private AudioSource audioSource;

    private void Start()
    {
        Camera = FindObjectOfType<Camera>();
        enemyGroup = FindObjectOfType<EnemyGroup>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (enemyType >= 3 && !inUI)
        {
            Invoke(nameof(checkOnScreen), 1);
        }

        switch (enemyType)
        {
            case 1:
                SetupLevelOne();
                break;
            case 2:
                SetupLevelTwo();
                break;
            case 3:
                SetupLevelThree();
                break;
            case 4:
                SetupLevelFour();
                break;
        }
    }

    private void checkOnScreen()
    {
        var screenPos = Camera.WorldToScreenPoint(transform.position);

        if (screenPos.x < Screen.width * 0.05)
        {
            if (enemyType == 3)
            {
                enemyGroup.OnEnemyHitLeft();
            }
            
        } else if (screenPos.x > Screen.width * 0.95)
        {
            if (enemyType == 3)
            {
                enemyGroup.OnEnemyHitRight();
            }
        }

        Invoke(nameof(checkOnScreen), 1);
    }

    private void Update()
    {
        if (canShoot && !inUI && (Random.value < shootChance) && !enemyGroup.paused)
        {
            var shot = Instantiate(bullet, transform.position, Quaternion.identity);
            audioSource.Play();
            Destroy(shot, 3f);
        }

        if (enemyType == 4 && !inUI)
        {
            transform.position += new Vector3(0.001f, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            OnEnemyDestroyed.Invoke(pointValue);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(this.gameObject);

            var remainingEnemy = FindObjectsByType<Enemy>(FindObjectsSortMode.InstanceID);
            if (remainingEnemy.Length < 2)
            {
                print("All Enemies Killed");
                OnAllEnemiesKilled.Invoke();
            }
        }

    }

    public void SetupLevelOne()
    {
        animator = GetComponent<Animator>();
        pointValue = 10;
        enemyType = 1;
        animator.SetInteger("EnemyType", 1);
    }

    public void SetupLevelTwo()
    {
        animator = GetComponent<Animator>();
        pointValue = 20;
        enemyType = 2;
        animator.SetInteger("EnemyType", 2);
    }

    public void SetupLevelThree()
    {
        animator = GetComponent<Animator>();
        pointValue = 40;
        canShoot = true;
        enemyType = 3;
        animator.SetInteger("EnemyType", 3);
    }

    public void SetupLevelFour()
    {
        animator = GetComponent<Animator>();
        pointValue = Random.Range(50, 300);
        enemyType = 4;
        animator.SetInteger("EnemyType", 4);
        Destroy(this.gameObject, 10);
    }
}
