using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Public method to reduce health
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }

    void Update()
    {
        // Check if health is 0 or below
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
