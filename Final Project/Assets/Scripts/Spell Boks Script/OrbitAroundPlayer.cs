using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundPlayer : MonoBehaviour
{
    public Transform parentTransform;
    public float orbitSpeed = 100f; // Degrees per second

    private Vector3 initialOffset; // Initial offset from parent
    private Quaternion initialRotation;

    void Start()
    {
        if (parentTransform != null)
        {
            // Calculate initial offset from parent
            initialOffset = transform.position - parentTransform.position;
            // Store initial rotation
            initialRotation = transform.rotation;
        }
        else
        {
            Debug.LogWarning("Parent transform not assigned.");
        }
    }

    void Update()
    {
        if (parentTransform != null)
        {
            // Rotate the initial offset around Y-axis
            float angleThisFrame = orbitSpeed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(0, angleThisFrame, 0);
            initialOffset = rotation * initialOffset;

            // Update position based on parent's current position
            transform.position = parentTransform.position + initialOffset;

            // Keep rotation fixed
            transform.rotation = initialRotation;
        }
    }
}
