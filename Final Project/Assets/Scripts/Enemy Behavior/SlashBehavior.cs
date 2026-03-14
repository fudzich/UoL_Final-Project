using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBehavior : MonoBehaviour
{
    [SerializeField] public float meleeDamage = 20f;
    [SerializeField] protected float lifetime = 2f;

    void Start()
    {
        if(gameObject.tag != PlayerInfo.tag)
            meleeDamage+= PlayerInfo.playerBias;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Avoid damaging objects with the same tag as the bullet
        if (other.gameObject.tag != this.tag)
        {
            if(other.name == "Player")
            {
                var health = other.GetComponent<PlayerHealthManagement>();
                if (health != null)
                {
                    health.TakeDamage(meleeDamage);
                }
                Destroy(gameObject);
            }
            // Try to get the HealthManagement component from the other object
            else{
                var health = other.GetComponent<HealthManagement>();
                if (health != null)
                {
                    health.TakeDamage(meleeDamage);
                }
                Destroy(gameObject);
            }
        }
        
    }
}
