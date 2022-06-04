using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;   
    private void OnCollisionExit(Collision other)
    {
        var velocity = rb.velocity;
        
        //after a collision we accelerate a bit
        velocity += velocity.normalized * 0.5f;
        
        //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.01f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        //max velocity
        if (velocity.magnitude > 3.0f)
        {
            velocity = velocity.normalized * 2.5f;
        }

        rb.velocity = velocity;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            SubManager.sub.UpdateStrike();
        }
        else if(other.gameObject.CompareTag("Top"))
        {
            rb.AddForce(Vector3.down * 5f);
        }
        else
        {
            rb.velocity *= 1.05f;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Top":
                rb.velocity = Vector3.down * 3;
                break;
            case "Ground":
                rb.velocity = Vector3.up * 3;
                break;
            case "Right":
                rb.velocity = Vector3.up * 3 + Vector3.left * 3;
                break;
            case "Left":
                rb.velocity = Vector3.up * 3 + Vector3.right * 3;
                break;
        }
    }
}
