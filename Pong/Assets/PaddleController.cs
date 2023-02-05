using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float unitsPerSecond = 5;
    public int PlayerId;
    public CameraShaker CameraShaker;

    private Rigidbody rb;

    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        rb.velocity = PlayerId switch
        {
            0 => Vector3.right * (Input.GetAxis("Vertical") * unitsPerSecond),
            1 => Vector3.right * (Input.GetAxis("Vertical2") * unitsPerSecond),
            _ => rb.velocity
        };
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            BallController ballController = collision.gameObject.GetComponent<BallController>();
            Bounds bounds = boxCollider.bounds;
            float colPerc = ((collision.transform.position.x - bounds.min.x)/(bounds.max.x - bounds.min.x)) * 2 - 1;

            float baseRotation = -60 * (-1 * PlayerId);
            Quaternion rotation = Quaternion.Euler(0f, 0f, baseRotation * colPerc);
            Vector3 bounceDirection = rotation * (PlayerId == 0 ? Vector3.up : Vector3.down);
            collision.rigidbody.AddForce(bounceDirection * ballController.speed);
            ballController.IncreaseBallSpeed();
            CameraShaker.shakeAmount = 0.1f;
            CameraShaker.shakeDuration = 0.2f;
        }
    }
}
