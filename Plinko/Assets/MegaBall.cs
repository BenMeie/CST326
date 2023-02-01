using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MegaBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

    private void Update()
    {
        transform.Translate(0, -5 * Time.deltaTime, 0);
    }
}
