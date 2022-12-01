using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//reference https://www.youtube.com/watch?v=UCwwn2q4Vys&t=354s 

public class FerretMovement : MonoBehaviour
{
    public Transform orientation;
    public float moveSpeed;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;

    public float airMultiplier;
    bool readyToJump;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    Rigidbody rb;
    public Animator ferretAnimation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        //check if ferret is touching ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        //get input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if(Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;
            ferretAnimation.SetBool("Jump", true);
            Jump();
            Invoke(nameof(JumpReset), jumpCooldown);
        }

        //control speed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        //character drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;


        Debug.Log("ground: " + grounded);

    }

    private void FixedUpdate()
    {

        //movement
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)//on ground
        {
            if(rb.velocity != new Vector3 (0,0,0))
            {
                ferretAnimation.SetBool("Walk", true);
            }
            else if (rb.velocity == new Vector3(0, 0, 0))
            {
                //idle animation
                ferretAnimation.SetBool("Walk", false);
            }

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)//on air
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void JumpReset()
    {
        ferretAnimation.SetBool("Jump", false);
        readyToJump = true;
    }
}
