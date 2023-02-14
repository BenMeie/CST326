using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void Start()
    {
        this.GetComponentInChildren<ParticleSystem>().Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        other.gameObject.GetComponent<BallController>().ApplyPowerUp();
        this.GetComponentInChildren<ParticleSystem>().Play();
        Destroy(this.gameObject, 1f);

    }
}
