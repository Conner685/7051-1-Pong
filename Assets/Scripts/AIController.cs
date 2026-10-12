using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform ball;
    [SerializeField] private float speed = 25f;

    void FixedUpdate()
    {
        float zDiff = ball.position.z - transform.position.z;
        zDiff = zDiff < 0 ? -1 : 1;
        Vector3 targetPos =  new Vector3(0, 2, zDiff);
        //if (Mathf.Abs(zDiff) > 1f)
        //{
        //    float direction = Mathf.Sign(zDiff);
        //    rb.linearVelocity = new Vector3(0, 0, speed * direction);
        //}
        
        rb.AddForce(speed * targetPos);
        if (Mathf.Abs(rb.linearVelocity.z) > speed)
        {
            rb.linearVelocity =  speed * targetPos;
        }
    }
}
