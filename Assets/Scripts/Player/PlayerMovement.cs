using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 10.0f; //For movement of the character
    [SerializeField] private float sprintMultiplier = 2f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckDistance;

    private CharacterController characterController;
    private Vector3 playerVelocity;
    public bool isGrounded { get; private set; }
    private float moveMultiplier = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        playerInput = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        MovePlayer();
    }
    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
    }

    private void MovePlayer()
    {
        moveMultiplier = playerInput.sprintHeld ? sprintMultiplier : 1; //Tenary Operator to check to see if the Input is true, it return sprintMultiplier, and if it is false, it returns the value of 1.
        characterController.Move((transform.forward * playerInput.vertical + transform.right * playerInput.horizontal)
            * moveSpeed * moveMultiplier * Time.deltaTime);//0,0,1 multiplied by vertical Input is for transform.forward and 1,0,0 multiplied by horizontal Input is for transform.right

        //Ground Check
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
