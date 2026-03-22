using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDamage : MonoBehaviour
{
    [SerializeField] private float damage = 300f;
    public int maxTriggerCounters = 2;
    private int triggerCounters = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Avoid damaging objects with the same tag as the bullet
        if (other.gameObject.tag != this.tag)
        {
            var health = other.GetComponent<HealthManagement>();
            if (health != null)
            {
                health.TakeDamage(damage * PlayerInfo.dmgIncrease);
            }
            triggerCounters++;
            // Destroy boulder when it hits max amount of enemies
            if(triggerCounters >= maxTriggerCounters)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
