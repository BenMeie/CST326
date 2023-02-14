using System;
using UnityEngine;

public class LookAt : MonoBehaviour {
    // todo - make an object look at another object
    public Transform target;

    private void Update()
    {
        transform.LookAt(target, Vector3.up);
    }
}
