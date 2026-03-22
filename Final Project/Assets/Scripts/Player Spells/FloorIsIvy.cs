using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsIvy : MonoBehaviour
{
    public float damage = 0;
    private float damageTimer = 0f;

    private void OnTriggerStay(Collider other)
    {
        DoDamage(other);
        DoSlow(other);
    }

    private void OnTriggerExit(Collider other)
    {
        StopDamage(other);
        StopSlow(other);
    }


    private void DoDamage(Collider other)
    {
        // Check if the object has different element
        if (other.gameObject.tag != this.tag)
        {
            // Increment the timer
            damageTimer += Time.deltaTime;

            // Apply damage every 1 second
            if (damageTimer >= 1f)
            {
                var health = other.GetComponent<HealthManagement>();
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
                damageTimer = 0f;
            }
        }
    }

    //Slow down enemies
    private void DoSlow(Collider other)
    {
        if (other.gameObject.tag != this.tag)
        {
            var movement = other.GetComponent<MeleeEnemyBehavior>();
            if (movement != null)
            {
                movement.ModifySpeed();
            }
        }
    }

    private void StopDamage(Collider other)
    {
        if (other.gameObject.tag != this.tag)
        {
            // Reset timer when enemy leaves
            damageTimer = 0f;
        }
    }

    private void StopSlow(Collider other)
    {
        if (other.gameObject.tag != this.tag)
        {
            var movement = other.GetComponent<MeleeEnemyBehavior>();
            if (movement != null)
            {
                movement.ResetSpeed();
            }
        }
    }
}
