using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10f;
    [SerializeField] private float speedMultiplier = 1.15f;
    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        
        LaunchBall();
    }

    public void LaunchBall()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float z = Random.value < 0.5f ? -1f : 1f;
        
        Vector3 direction = new Vector3(x, 0, z).normalized;
        rb.linearVelocity = direction * initialSpeed;
        
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        
        Invoke(nameof(LaunchBall), 1f);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Paddle"))
        {
            float zDifference = transform.position.z - collision.transform.position.z;

            //Custom made so it has the pong directional field of hitting on a specific side launches it the opposite way
            float paddleHalfLength = collision.collider.bounds.size.z / 2f;
            float zDirection = zDifference / paddleHalfLength;


            float xDirection = collision.transform.position.x < transform.position.x ? 1f : -1f;

            Vector3 bounceDirection = new Vector3(xDirection, 0f, zDirection).normalized;

            float currentSpeed = Mathf.Max(rb.linearVelocity.magnitude, initialSpeed);
            float newSpeed = Mathf.Min(currentSpeed * speedMultiplier, maxSpeed);

            rb.linearVelocity = bounceDirection * newSpeed;
        }
    }
}
