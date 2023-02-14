using System;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
  public float impulseStrength = 1f;
  public AudioClip clip;
  private AudioSource audioSource;

  private void Awake()
  {
    audioSource = GetComponent<AudioSource>();
    audioSource.loop = false;
    audioSource.playOnAwake = false;
  }

  void OnCollisionEnter(Collision collision)
  {
    Debug.Log($"{this.name} collided with the {collision.gameObject.name}");
    Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
    rb.AddForce((transform.up * impulseStrength), ForceMode.Impulse);
    audioSource.clip = clip;
    audioSource.Play();
  }
}
