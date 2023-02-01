using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    
    public int slotNumber;
    public int pointValue;

    public ScoreHolder scoreHolder;

    private void OnTriggerEnter(Collider other)
    {
        scoreHolder.UpdateScore(pointValue);
        Destroy(other.GameObject(), 2);
    }
}
