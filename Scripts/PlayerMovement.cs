using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 15;
    private Vector3 move;

    public float gravity = -10f;
    public float jumpHeight = 2;
    public Vector3 velocity;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    public Animator animator;


    InputAction movement;
    InputAction jump;


    public FixedJoystick joystick;



    // Start is called before the first frame update
    void Start()
    {
        //movement for keyboard
        jump = new InputAction("Jump", binding: "<keyboard>/space");
        jump.AddBinding("<Gamepad>/a");
        movement = new InputAction("playerMovement", binding: "<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
        .With("Up", "<keyboard>/w")
        .With("Up", "<keyboard>/upArrow")
        .With("Down", "<keyboard>/s")
        .With("Down", "<keyboard>/downArrow")
        .With("Left", "<keyboard>/a")
        .With("Left", "<keyboard>/leftArrow")
        .With("Right", "<keyboard>/d")
        .With("Right", "<keyboard>/rightArrow");

        movement.Enable();
        jump.Enable();

    }

    // Update is called once per frame
    void Update()
    {


        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        //joystick 
        float x = joystick.Horizontal;
        float z = joystick.Vertical;
        //animator connect to the code
        animator.SetFloat("speed", Mathf.Abs(x) + Mathf.Abs(z));

        //Movement
        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);

        if (isGrounded && velocity.y < 0)
            velocity.y = -1f;


        if (isGrounded)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
    }
}
