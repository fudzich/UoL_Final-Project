using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBehavior : MonoBehaviour
{
    [SerializeField] public float meleeDamage = 20f;
    [SerializeField] protected float lifetime = 2f;

    void Start()
    {
        //Increase damage in later arenas
        if(gameObject.tag != PlayerInfo.tag)
            meleeDamage+= PlayerInfo.playerBias;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Avoid damaging objects with the same tag as the slash
        if (other.gameObject.tag != this.tag)
        {
            // Try to get the HealthManagement component from Player
            if(other.name == "Player")
            {
                var health = other.GetComponent<PlayerHealthManagement>();
                if (health != null)
                {
                    health.TakeDamage(meleeDamage);
                }
            }
            // Try to get the HealthManagement component from the other object
            else{
                var health = other.GetComponent<HealthManagement>();
                if (health != null)
                {
                    health.TakeDamage(meleeDamage);
                }
            }
        }
        
    }
}
