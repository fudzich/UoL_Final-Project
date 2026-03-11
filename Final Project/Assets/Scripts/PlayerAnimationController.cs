using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Vector3 moveDir = playerMovement.movementDirection;

        // If no movement, reset all booleans
        if (moveDir.magnitude < 0.01f)
        {
            animator.SetBool("m_forward", false);
            animator.SetBool("m_left", false);
            animator.SetBool("m_back", false);
            animator.SetBool("m_right", false);
            return;
        }

        // Get the player's forward and right vectors
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Normalize movement direction
        Vector3 moveDirNormalized = moveDir.normalized;

        // Calculate dot products to determine relative direction
        float forwardDot = Vector3.Dot(moveDirNormalized, forward);
        float rightDot = Vector3.Dot(moveDirNormalized, right);

        // Threshold to determine dominant direction
        float threshold = 0.3f;

        // Reset all
        animator.SetBool("m_forward", false);
        animator.SetBool("m_left", false);
        animator.SetBool("m_back", false);
        animator.SetBool("m_right", false);

        // Assign based on dominant direction
        if (forwardDot > threshold)
        {
            animator.SetBool("m_forward", true);
        }
        else if (forwardDot < -threshold)
        {
            animator.SetBool("m_back", true);
        }
        else if (rightDot > threshold)
        {
            animator.SetBool("m_right", true);
        }
        else if (rightDot < -threshold)
        {
            animator.SetBool("m_left", true);
        }
    }

    public void PlayerDead()
    {
        animator.SetBool("dead", true);
        //animator.SetBool("dead", false);
    }
}
