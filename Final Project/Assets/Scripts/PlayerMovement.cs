using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    //private Animator animator;

    Rigidbody rb;

    [SerializeField]
    float movementSpeed = 10f;

    public Vector3 movementDirection { get; private set; }

    [SerializeField]

    private float speedSlower = 0f;


    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();

        //animator = GetComponent<Animator>();

        movementDirection = Vector3.zero;
    }
    private void FixedUpdate()
    {
        float vertical_movement = Input.GetAxisRaw("Vertical");
        float horizontal_movement = Input.GetAxisRaw("Horizontal");

        Vector3 inputDir = new Vector3(horizontal_movement, 0, vertical_movement).normalized;
        Vector3 moveDir = inputDir * (movementSpeed - speedSlower) * Time.deltaTime;

        rb.MovePosition(transform.position + moveDir);

        if (inputDir.magnitude == 0)
        {
            rb.velocity = Vector3.zero;
            movementDirection = Vector3.zero;
        }
        else
        {
            //animator.SetBool("m_forward", true);
            // Update movementDirection with the input direction (world space)
            movementDirection = moveDir.normalized;
        }

    }

    public void ModifySpeed()
    {
        speedSlower = movementSpeed / 2;
    }

    public void ResetSpeed()
    {
        speedSlower = 0f;
    }

}
