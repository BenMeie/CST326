using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
  public ScoreManager scoreManger;
  private AudioSource audioSource;

  private void Awake()
  {
    audioSource = GetComponent<AudioSource>();
  }

  void OnTriggerExit()
  {
    audioSource.Play();
    scoreManger.AddScore();
  }
}
