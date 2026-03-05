using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBehavior : MonoBehaviour
{
    [SerializeField] private float meleeDamage = 20f;
    [SerializeField] protected float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

     private void OnTriggerEnter(Collider other)
    {
        // Avoid damaging objects with the same tag as the bullet
        if (other.gameObject.tag != this.tag)
        {
            // Try to get the HealthManagement component from the other object
            var health = other.GetComponent<HealthManagement>();
            if (health != null)
            {
                health.TakeDamage(meleeDamage);
            }
            Destroy(gameObject);
        }
        
    }
}
