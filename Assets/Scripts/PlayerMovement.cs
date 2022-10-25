using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpForce = 1f;
    public Rigidbody rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool Grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
    private void FixedUpdate()
    {
        Move();        
        Grounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
    }

    private void Move()
    {
        Vector3 movement = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
