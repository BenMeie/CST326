using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public float zOffset;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Math.Clamp(player.transform.position.x, 15, 200), Math.Clamp(player.transform.position.y, 7, 15), zOffset);
    }
}
