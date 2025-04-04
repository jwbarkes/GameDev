using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float speed;
    public float gravity = -0.1f;

    private float tiltAmount;   // How much the car tilts
    public float normalTilt = 10f;
    public float sprintTilt = 25f;
    public float tiltSpeed = 5f;     // How quickly it tilts

    public float normalSpeed = 6f;
    public float sprintSpeed = 10f;
    public float turnSpeed = 60f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = normalSpeed;
        tiltAmount = normalTilt;
    }

    void Update()
    {
        Vector3 move = Vector3.zero;
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = sprintSpeed;
            tiltAmount = sprintTilt;
        }
        else {
            speed = normalSpeed;
            tiltAmount = normalTilt;
        }

        if (Input.GetKey(KeyCode.W))
        {
            move += transform.forward;
            verticalInput = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += -transform.forward;
            verticalInput = -1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                horizontalInput = -1f; // Track left turn
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                horizontalInput = 1f; // Track right turn
            }
            controller.Move(move.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
                horizontalInput = -1f; // Track left turn
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
                horizontalInput = 1f; // Track right turn
            }
            controller.Move(move.normalized * speed * Time.deltaTime);
        }

        // --- Gravity Handling ---
        if (controller.isGrounded)
        {
            velocity.y = -0.5f; // Small negative value to keep it on the ground
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // Apply gravity continuously
        }
        controller.Move(velocity * Time.deltaTime);

        // --- Tilt Logic ---
        float targetTiltZ = horizontalInput * tiltAmount;  // Lean left/right
        float targetTiltX = -verticalInput * tiltAmount * 0.3f;  // Slight nose tilt on accel/brake

        Quaternion targetRotation = Quaternion.Euler(targetTiltX, transform.eulerAngles.y, targetTiltZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);
    }
}
