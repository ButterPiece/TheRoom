using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    public float groundDrag;

    //public float jumpForce;
    //public float jumpCooldown;
    public float airMultiplier;
    //bool readyToJump;

    //[Header("Keybinds")]
    //public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rigidbody;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);


        MyInput();
        SpeedControl();

        if (grounded)
        {
            rigidbody.drag = groundDrag;
            //readyToJump = true;
        }
        else
        {
            rigidbody.drag = 0;
        }
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //if(Input.GetKey(jumpKey) && readyToJump && grounded)
        //{
            //readyToJump = false;

            //Jump();
            //Invoke(nameof(ResetJump), jumpCooldown);
        //}
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward*verticalInput+orientation.right*horizontalInput;

        if(grounded)
            rigidbody.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
        else if(!grounded)
            rigidbody.AddForce(moveDirection.normalized * MoveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);

        if(flatVel.magnitude > MoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MoveSpeed;
            rigidbody.velocity = new Vector3(limitedVel.x, rigidbody.velocity.y, limitedVel.z);
        }
    }

    //private void Jump()
    //{
        //rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);

        //rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    //}

    //private void ResetJump()
    //{
        //readyToJump = true;
    //}
}
