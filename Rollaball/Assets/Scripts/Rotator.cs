using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rotator : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        decimal deltaDec = new decimal(Time.time);
        transform.Rotate(new Vector3((float)Math.Sin((double)deltaDec * 2) * 180 + (Random.Range(30f, 50f)), (float)Math.Sin((double)deltaDec/2) * 270 -  + (Random.Range(10f, 20f)), (float)Math.Sin((double)deltaDec * 3) * 360) * Time.deltaTime);
    }
}
