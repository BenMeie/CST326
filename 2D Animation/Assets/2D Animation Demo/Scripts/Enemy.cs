using System;
using UnityEngine;

public class EnemyComplete : MonoBehaviour
{
    private Animator enemyAnimator;

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    //-----------------------------------------------------------------------------
    void OnCollisionEnter2D(Collision2D collision)
    {
        enemyAnimator.SetTrigger("Explode");
        Destroy(collision.gameObject); // destroy bullet
        Debug.Log("Ouch!");
    }
}
