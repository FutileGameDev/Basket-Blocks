using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float force;
    [SerializeField]
    private Rigidbody rb;
    public float Speed = 2.0f;
    public float MaxMovement = 2.0f;
    private float degree = -30f;
    Quaternion dir = Quaternion.identity;
    private bool started = false;
    
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)
    {
        if(started && other.gameObject.CompareTag("Base"))
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * 10f);
                rb.gameObject.transform.parent = null;
                started = true;
            }
        }
        if(started && Input.GetKeyDown(KeyCode.Space))
        {
            degree = -degree;
        }
        if(started && Input.GetKey(KeyCode.Space))
        {
            dir = Quaternion.Euler(0, 0, degree);
            transform.rotation = dir;
        }
        if(started && Input.GetKeyUp(KeyCode.Space))
        {
            dir = Quaternion.identity;
            transform.rotation = dir;
        }
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * Speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;

        transform.position = pos;
    }
}
