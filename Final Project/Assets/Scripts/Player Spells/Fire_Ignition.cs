using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Ignition : MonoBehaviour
{
    public LayerMask interactableLayer;

    [SerializeField]
    private float dmgLVL1 = 50f;
    [SerializeField]
    private float dmgLVL2 = 80f;
    [SerializeField]
    private float dmgLVL3 = 100f;


    [SerializeField]
    private float maxMultiplierLVL1 = 2f;
    [SerializeField]
    private float maxMultiplierLVL2 = 3f;
    [SerializeField]
    private float maxMultiplierLVL3 = 4f;
    private float dmgMultiplier;

    [SerializeField]
    private GameObject effectPrefab; // Prefab to instantiate at hit point

    [SerializeField]
    private List<string> elementTags;

    public void Ignite(int lvl)
    {
        // Create a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Cast the ray
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
        {
            GameObject hoveredObject = hit.collider.gameObject;

            // Check if the hovered object has a different tag
            if (elementTags.Contains(hoveredObject.tag) && hoveredObject.gameObject.tag != this.tag)
            {
                if (effectPrefab != null)
                {
                    Instantiate(effectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                }

                //Debug.Log("Hit Somethinh");
                // Access the HealthManagement component
                HealthManagement health = hoveredObject.GetComponent<HealthManagement>();
                if (health != null)
                {
                    
                    float playerHealth = GetComponent<PlayerHealthManagement>().GetCurrentHealth();
                    
                    switch (lvl)
                    {
                        case 1:
                            dmgMultiplier = CalculateDamageMultiplier(playerHealth, PlayerInfo.maxHealth, maxMultiplierLVL1);
                            health.TakeDamage(dmgLVL1 * dmgMultiplier * PlayerInfo.dmgIncrease);
                            //Debug.Log("Damage Dealt: " + (dmgLVL1 * dmgMultiplier) + PlayerInfo.dmgIncrease);
                            break;
                        case 2:
                            dmgMultiplier = CalculateDamageMultiplier(playerHealth, PlayerInfo.maxHealth, maxMultiplierLVL2);
                            health.TakeDamage(dmgLVL2 * dmgMultiplier * PlayerInfo.dmgIncrease);
                            break;
                        case 3:
                            dmgMultiplier = CalculateDamageMultiplier(playerHealth, PlayerInfo.maxHealth, maxMultiplierLVL3);
                            health.TakeDamage(dmgLVL3 * dmgMultiplier * PlayerInfo.dmgIncrease);
                            break;
                        default:
                            dmgMultiplier = CalculateDamageMultiplier(playerHealth, PlayerInfo.maxHealth, maxMultiplierLVL3);
                            health.TakeDamage(dmgLVL3 * dmgMultiplier * PlayerInfo.dmgIncrease);
                            break;
                    }
                }
            }
        }
    }

    private float CalculateDamageMultiplier(float currentHealth, float maxHealth, float maxDamageMultiplier)
    {
        // Calculate the percentage of health remaining (0 to 1)
        float healthPercent = currentHealth / maxHealth;

        // Optional: Clamp the value between 0 and 1 to avoid invalid percentages
        healthPercent = Mathf.Clamp01(healthPercent);

        // Calculate the damage multiplier based on how low the health is
        float minDamageMultiplier = 1f; // no increase at full health
        float damageMultiplier = Mathf.Lerp(minDamageMultiplier, maxDamageMultiplier, 1 - healthPercent);

        return damageMultiplier;
    }
}
