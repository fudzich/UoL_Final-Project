using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoDamage : MonoBehaviour
{
    public float damage = 0;

    [SerializeField]
    private List<string> elementTags;


    private void OnTriggerEnter(Collider other)
    {
        // Avoid damaging objects with the same tag as the bullet
        if (elementTags.Contains(other.tag) && other.gameObject.tag != this.tag)
        {
            var health = other.GetComponent<HealthManagement>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        
    }
}
