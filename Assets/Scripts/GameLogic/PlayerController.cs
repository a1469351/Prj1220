using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    private float xInput;
    private float yInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        CheckInput();
    }

    private void Movement()
    {
        rb.velocity = new Vector3(xInput * moveSpeed, rb.velocity.y, yInput * moveSpeed);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
