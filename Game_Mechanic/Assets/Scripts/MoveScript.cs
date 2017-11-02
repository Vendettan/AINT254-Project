using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    private Rigidbody rigidbody;
    private float acceleration = 6.0f;
    private float maxSpeed = 20.0f;
    private float jumpPower = 700.0f;
    private bool isGrounded;
    private float distToGround;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
	

	void Update ()
    {                           
        rigidbody.AddForce(transform.right * Input.GetAxis("Horizontal") * acceleration);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded())
            {
                rigidbody.AddForce(transform.up * Input.GetAxis("Vertical") * jumpPower, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        else
        {
            rigidbody.AddForce(transform.up * -4);
        }
    }    

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void LateUpdate()
    {
        Vector3 newVelocity = rigidbody.velocity;

        if (newVelocity.x > maxSpeed)
        {
            newVelocity.x = maxSpeed;
        }

        if (newVelocity.y > maxSpeed)
        {
            newVelocity.y = maxSpeed;
        }

        rigidbody.velocity = newVelocity;
    }
}
