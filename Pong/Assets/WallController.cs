using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            collision.rigidbody.AddForce(new Vector3(collision.rigidbody.velocity.x * 2, collision.rigidbody.velocity.y * 2, 0));
        }
    }
}
