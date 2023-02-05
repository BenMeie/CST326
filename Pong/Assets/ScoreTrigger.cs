using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public int triggerId;
    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        switch (triggerId)
        {
            case 0:
                gameController.IncrementPlayer1Score();
                break;
            case 1:
                gameController.IncrementPlayer2Score();
                break;
        }
    }
}
