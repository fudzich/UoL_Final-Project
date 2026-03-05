using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private float bulletDamage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        // Avoid damaging objects with the same tag as the bullet
        if (other.gameObject.tag != this.tag)
        {
            // Try to get the HealthManagement component from the other object
            var health = other.GetComponent<HealthManagement>();
            if (health != null)
            {
                health.TakeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }
        
    }
}
