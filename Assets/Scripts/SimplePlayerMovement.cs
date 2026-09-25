using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayerMovement : MonoBehaviour
{
    public float moveForce = 20f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveDirection = Vector3.zero;

        if (Keyboard.current == null)
            return;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            moveDirection += Vector3.forward;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            moveDirection += Vector3.back;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            moveDirection += Vector3.left;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            moveDirection += Vector3.right;

        moveDirection = moveDirection.normalized;

        // Jump when Space is pressed
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(moveDirection * moveForce, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Player is touching the ground
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        // Player is no longer touching the ground
        isGrounded = false;
    }
}

