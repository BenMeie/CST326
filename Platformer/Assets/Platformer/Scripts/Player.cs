using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public UIManager UIManager;
    
    private Rigidbody rb;
    private bool onGround;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.velocity += new Vector3(0, jumpHeight, 0);
        }
        
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, 0);

        onGround = Physics.Raycast(transform.position, Vector3.down, 1.2f);

        if (Physics.Raycast(transform.position, Vector3.up, out var raycastHit, 1))
        {
            var collisionObject = raycastHit.collider.gameObject;
            if (collisionObject.CompareTag("Brick"))
            {
                Destroy(collisionObject);
            } else if (collisionObject.CompareTag("Question"))
            {
                Debug.Log("Question Block");
                UIManager.IncrementCoins();
            }
        }
    }
}
