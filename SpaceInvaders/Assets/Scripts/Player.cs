using System;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class Player : MonoBehaviour
{
  public delegate void PlayerKilled();
  public static event PlayerKilled OnPlayerKilled;
  
  public GameObject bullet;
  public float maxSpeed;
  public GameObject explosionPrefab;

  public AudioSource audioSource;
  // public ParticleSystem rightSkidParticles;
  // public ParticleSystem leftSkidParticles;

  private Rigidbody2D rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  public Transform shootingOffset;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
        audioSource.Play();
        Destroy(shot, 3f);

      }

      rb.velocity += new Vector2(Input.GetAxis("Horizontal"), 0);
      rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

      if (Input.GetAxis("Horizontal") < 0.1 && Input.GetAxis("Horizontal") > -0.1)
      {
        rb.velocity = new Vector2(rb.velocity.x / 5, rb.velocity.y / 5 );
      }

      // if (Input.GetAxis("Horizontal") > 0 && !rightSkidParticles.isPlaying)
      // {
      //   rightSkidParticles.Play();
      // }
      // else
      // {
      //   rightSkidParticles.Stop();
      // }
      //
      // if (Input.GetAxis("Horizontal") < 0 && !leftSkidParticles.isPlaying)
      // {
      //   leftSkidParticles.Play();
      // }
      // else
      // {
      //   leftSkidParticles.Stop();
      // }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.CompareTag("EnemyBullet"))
      {
        OnPlayerKilled.Invoke();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
      }
    }
}
