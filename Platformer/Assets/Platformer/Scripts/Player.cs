using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float maxSpeed;
    private float maxUnBoost;
    public UIManager UIManager;
    
    private Rigidbody rb;
    private Collider collider;
    private Animator animator;
    private bool onGround;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        maxUnBoost = maxSpeed;
    }

    private void Update()
    {
        // On Ground Detection
        float halfHeight = collider.bounds.size.y/2;
        Vector3 offset = new Vector3(0, 0.6f, 0);
        onGround = Physics.Raycast(transform.position + offset, Vector3.down, halfHeight);
        
        // Animator Updates
        animator.SetFloat("Speed", Math.Abs(rb.velocity.x));
        animator.SetBool("Jumping", !onGround);
    }

    private void FixedUpdate()
    {
        //Store access variables for performance
        Vector3 velocity = rb.velocity;
        float yRotation = (velocity.x >= 0f) ? 0.70711f : -0.7011f;
        
        // Movement and speed clamping
        velocity += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0, 0);
        velocity = new Vector3(Math.Clamp(velocity.x, -maxSpeed, maxSpeed), velocity.y, velocity.z);
        rb.velocity = velocity;
        
        //Collision Detection
        if (Physics.Raycast(transform.position + (Vector3.up * 0.6f), Vector3.up, out var raycastHit, collider.bounds.size.y/2))
        {
            var collisionObject = raycastHit.collider.gameObject;
            if (collisionObject.CompareTag("Brick"))
            {
                UIManager.IncrementScore(100);
                Destroy(collisionObject);
            } else if (collisionObject.CompareTag("Question"))
            {
                UIManager.IncrementCoins();
                UIManager.IncrementScore(100);
                rb.AddForce(Vector3.down * 4, ForceMode.Impulse);
            }
        }

        // Add Artificial drag
        if (!Input.GetButton("Horizontal"))
        {
            rb.AddForce(-velocity.x * 10, 0, 0);
        }

        // Player Jumping
        if (Input.GetButton("Jump") && onGround)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            animator.SetBool("Jumping", true);
        }
        else if (!onGround && !Input.GetButton("Jump") && velocity.y > 0)
        {
            rb.AddForce(Vector3.down * 2, ForceMode.Impulse);
        }

        // Player Boosting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = maxSpeed + 5;
        } else if (maxSpeed != maxUnBoost)
        {
            maxSpeed = maxUnBoost;
        }
        
        // Player rotation
        if (velocity.magnitude > 0.2)
        {
            transform.rotation = new Quaternion(transform.rotation.x, yRotation, transform.rotation.z, transform.rotation.w);
        }
    }
}
