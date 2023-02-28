using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int totalTime;
    public int timeRemaining;
    public bool active;

    public void StartTimer()
    {
        timeRemaining = totalTime;
        active = true;
        Invoke(nameof(Countdown), 1f);
    }

    private void Countdown()
    {
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke(nameof(Countdown), 1f);
        }
        else
        {
            active = false;
        }
    }
}
