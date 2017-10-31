using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    private Rigidbody rigidbody;
    private float acceleration = 5.0f;
    private float maxSpeed = 13.0f;
    private float jumpPower = 400.0f;
    private bool isGrounded;


    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();        
      
    }
	

	void Update ()
    {                           
        rigidbody.AddForce(transform.right * Input.GetAxis("Horizontal") * acceleration);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigidbody.AddForce(transform.up * Input.GetAxis("Vertical") * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        isGrounded = true;
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
