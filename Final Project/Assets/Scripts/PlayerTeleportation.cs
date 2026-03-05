using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    [SerializeField]
    private float teleportDistance = 5f; // The distance to teleport

    void Update()
    {
        // Check if SPACE is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Determine direction based on WASD keys
            Vector3 direction = Vector3.zero;

            bool wPressed = Input.GetKey(KeyCode.W);
            bool aPressed = Input.GetKey(KeyCode.A);
            bool dPressed = Input.GetKey(KeyCode.D);
            bool sPressed = Input.GetKey(KeyCode.S);

            // Determine direction based on pressed keys
            if (wPressed && sPressed)
            {
                // If both W and S are pressed, ignore vertical movement
                // or you could choose to prioritize one
            }
            else if (wPressed)
            {
                direction += Vector3.forward;
            }
            else if (sPressed)
            {
                direction += Vector3.back;
            }

            if (aPressed && dPressed)
            {
                // If both A and D are pressed, ignore horizontal movement
            }
            else if (aPressed)
            {
                direction += Vector3.left;
            }
            else if (dPressed)
            {
                direction += Vector3.right;
            }

            // Normalize direction if diagonal
            float moveDistance = teleportDistance;
            if (direction.magnitude > 0)
            {
                // Check if multiple keys are pressed for diagonal movement
                int keysPressedCount = (wPressed ? 1 : 0) + (aPressed ? 1 : 0) + (sPressed ? 1 : 0) + (dPressed ? 1 : 0);
                if (keysPressedCount > 1)
                {
                    moveDistance /= 2f; // Half distance for diagonal
                }
                direction = direction.normalized;
            }

            // Calculate new position
            Vector3 newPosition = transform.position + direction * moveDistance;

            // Change only the Y position
            newPosition.y = transform.position.y;

            // Teleport the player
            transform.position = newPosition;
        }
    }
}
