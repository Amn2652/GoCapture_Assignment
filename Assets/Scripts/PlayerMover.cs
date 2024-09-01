using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationSpeed = 700f;
    public string horizontalInput; // Custom input axis for horizontal movement
    public string verticalInput;   // Custom input axis for vertical movement
    private Animator animator;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the custom keys
        float moveX = Input.GetAxis(horizontalInput);
        float moveZ = Input.GetAxis(verticalInput);

        // Set the movement direction based on input
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Move the player
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Rotate the player towards the movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Update the animation based on whether the player is moving
        bool isWalking = moveDirection != Vector3.zero;
        animator.SetBool("Walk", isWalking);

        // Debug statements
        if (isWalking)
        {
            Debug.Log("Player is walking");
        }
        else
        {
            Debug.Log("Player is idle");
        }
    }
}
