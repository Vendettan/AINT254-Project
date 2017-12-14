using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    private Rigidbody rigidbody;
    private float acceleration = 6.0f;
    private float maxSpeed = 20.0f;
    private float jumpPower = 600.0f;
    private float sideJumpPower = 400.0f;
    private bool isGrounded;
    private float distToGround;  
    private StateScript stateScript;
    private bool isDead;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        InvokeRepeating("IncreaseMaxSpeed", 5.0f, 1.0f); // Increase speed every 30s
    }
      
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            isDead = true;
        }
        
    }

    /// <summary>
    /// DYNAMIC WALL HALP :: Use a raycast to the left along with a compareTag for Track 
    /// to stop user moving into wall, have only back wall go up and front wall go down.
    /// </summary>


    void Update ()
    {
        if (!isDead)
        {
            // Right force constant
            rigidbody.AddForce(transform.right * acceleration);
        }
        else
        {
            maxSpeed = 10.0f;
        }

        // Jump with W
        if (Input.GetKeyDown(KeyCode.W) && !isDead || Input.GetKeyDown(KeyCode.Space))
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

        // Move left (Positive)
        if (Input.GetKeyDown(KeyCode.A) && !isDead)
        {
            if (rigidbody.position.z <= 0)
            {
                rigidbody.position = new Vector3(rigidbody.position.x, rigidbody.position.y, rigidbody.position.z + 5);
            }
        }

        // Move right (Negative)
        if (Input.GetKeyDown(KeyCode.D) && !isDead)
        {
            if (rigidbody.position.z >= 0)
            {
                rigidbody.position = new Vector3(rigidbody.position.x, rigidbody.position.y, rigidbody.position.z - 5);

            }
        }

        // Slam with S
        if (Input.GetKeyDown(KeyCode.S) && !isDead)
        {
            if (!IsGrounded())
            {
                rigidbody.AddForce(transform.up * -35, ForceMode.Impulse);
            }
        }
    }    

    // Check if grounded
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void LateUpdate()
    {
        // Limit speed
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


    // Add 5 to maxSpeed
    private void IncreaseMaxSpeed()
    {
        maxSpeed += 0.1f;
    }
}
