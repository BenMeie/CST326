using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float originalSpeed;
    public GameController gameController;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSpeed = speed;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 currentVelocity = rb.velocity;
        if (Math.Abs(currentVelocity.y) < speed && currentVelocity.y > 0 && currentVelocity.y < 2)
        {
            rb.AddForce(0, speed, 0);
        } else if (Math.Abs(currentVelocity.y) < speed && currentVelocity.y < 0 && currentVelocity.y > 2)
        {
            rb.AddForce(0, -speed, 0);
        }
    }

    public void IncreaseBallSpeed()
    {
        speed += 2;
    }

    public void ResetBall(int player)
    {
        speed = player switch
        {
            1 => -originalSpeed,
            2 => originalSpeed,
            _ => originalSpeed
        };
        rb.velocity = Vector3.zero;
        StartCoroutine(WaitToFire());
        transform.position = new Vector3(0, 1, 0);
    }

    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(1);
        rb.AddForce(0, speed, 0);
        speed = originalSpeed;
    }

    public void ApplyPowerUp()
    {
        gameController.ApplyPowerUp();
    }
    
}
