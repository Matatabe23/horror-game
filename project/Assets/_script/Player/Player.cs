using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 400f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    public Transform playerCamera;
    public float cameraSensitivity = 4f;
    public float minY = -45f;
    public float maxY = 45f;

    private float cameraRotationX = 0f;

    void Start()
    {
        CursorManager.HideCursor();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);

        float rotateY = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotateY * rotateSpeed * Time.deltaTime);

        float rotateX = Input.GetAxis("Mouse Y");
        cameraRotationX -= rotateX * cameraSensitivity;
        cameraRotationX = Mathf.Clamp(cameraRotationX, minY, maxY);
        playerCamera.localEulerAngles = new Vector3(cameraRotationX, 0f, 0f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
