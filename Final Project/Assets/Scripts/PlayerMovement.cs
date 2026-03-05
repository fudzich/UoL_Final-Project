using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;

    Rigidbody rb;

    [SerializeField]
    float movementSpeed = 10f;


    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float vertical_movement = Input.GetAxisRaw("Vertical");
        float horizontal_movement = Input.GetAxisRaw("Horizontal");

        Vector3 newPos = new Vector3(horizontal_movement, 0, vertical_movement) * movementSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + newPos);

        if (vertical_movement == 0 && horizontal_movement == 0)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

    }

}
