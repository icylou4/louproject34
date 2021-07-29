using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [Header("References")]
    public Animator animator;
    public GameObject playerModel;
    CharacterController myController;
    DoubleJump doubleJump;
    [Header("Movement")]
    public int moveSpeed;
    [Header("Jump")]
    public float yForce;
    public float yGravity;
    public float mGravity;
    public float jumpSpeed;
    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        isJumping = false;
        doubleJump = GetComponent<DoubleJump>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))   
        {
            MoveForward();
        } 
        if(Input.GetKey(KeyCode.S))   
        {
            MoveBackward();
        } 
        if(Input.GetKey(KeyCode.D))
        {
            MoveRight();
        } 
        if(Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        } 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isJumping)
            {
                Jump();
            }
            else
            {
                if(doubleJump.available)
                {
                    doubleJump.available = false;
                    Jump();
                }
            }

        }
        if(myController.isGrounded && yForce<0)
        {
            isJumping=false;
            doubleJump.available = true;
        }
        if(!myController.isGrounded)
        {
            yForce = Mathf.Max(mGravity,yForce+(yGravity*Time.deltaTime));
        }
        myController.Move(Vector3.up*yForce*Time.deltaTime);
        if(IsIdle())
        {
            animator.SetFloat("Speed",0);
        }
    }

    public bool IsIdle()
    {
        if( !Input.GetKey(KeyCode.W) &&
            !Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.S) &&
            !Input.GetKey(KeyCode.D) &&
            !isJumping)
        {
            return true;
        }
        return false;
    }

    

    void MoveLeft()
    {
        myController.Move(Vector3.left * Time.deltaTime * moveSpeed);
        playerModel.transform.eulerAngles = new Vector3(0,270,0);
        animator.SetFloat("Speed",1);
    }
    void MoveRight()
    {
        myController.Move(Vector3.right * Time.deltaTime * moveSpeed);
        playerModel.transform.eulerAngles = new Vector3(0,90,0);
        animator.SetFloat("Speed",1);
    }
    void MoveForward()
    {
        myController.Move(Vector3.forward * Time.deltaTime * moveSpeed);
        playerModel.transform.eulerAngles = new Vector3(0,0,0);
        animator.SetFloat("Speed",1);
    }
    void MoveBackward()
    {
        myController.Move(Vector3.back * Time.deltaTime * moveSpeed);
        playerModel.transform.eulerAngles = new Vector3(0,180,0);
        animator.SetFloat("Speed",1);
    }
    void Jump()
    {
        isJumping = true;
        yForce = jumpSpeed;
    }
}
