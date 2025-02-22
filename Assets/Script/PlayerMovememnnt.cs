using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovememnnt : MonoBehaviour
{
    [Header("Character")]
    [SerializeField] CharacterController CC;
    [SerializeField] Transform CharacterBody;
    [SerializeField] Transform groundCheck;

    [Header("Movement")]
    [SerializeField] float walkSpeed = 12f;
    [SerializeField] float runSpeed = 18f;
    [SerializeField] float jumpForce;

    public float Horizontal;
    public float Vertical;
    public static bool isRunning;
    public static bool isWalking;

    [Header("Gravity")]
    [SerializeField] float gravityAc = -9.18f * 2;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    Vector3 GravityVector;

    private void FixedUpdate()
    {
        Movement();
        Gravity();
    }

    private void Update()
    {
        Jumping();
        CheckMovement();
    }

    void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Vector3 Move = CharacterBody.right * Horizontal + CharacterBody.forward * Vertical;
        CC.Move(Move * TotalSpeed() * Time.deltaTime);
    }


    void CheckMovement()
    {
        if ((Horizontal != 0f || Vertical != 0f) || (Horizontal != 0f && Vertical != 0f))
        {
            if (TotalSpeed() == runSpeed)
            {
                isRunning = true;
                isWalking = false;
            }

            if (TotalSpeed() == walkSpeed)
            {
                isRunning = false;
                isWalking = true;
            }
        }
        else
        {
            isRunning = false;
            isWalking = false;
        }
    }

    void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundLayer);

        if (!isGrounded)
        {
            GravityVector.y += gravityAc * Mathf.Pow(Time.deltaTime, 2);
        }
        else if (GravityVector.y < 0f) 
        {
            GravityVector.y = -0.15f;
        }

        CC.Move(GravityVector);
    }

    void Jumping()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            GravityVector.y = Mathf.Sqrt(jumpForce * -2f * gravityAc / 1000f);
        }
    }

    float TotalSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }


 
}
