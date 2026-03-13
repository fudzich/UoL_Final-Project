using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Heal : MonoBehaviour
{
    [SerializeField]
    private float healLVL1 = 10f;
    [SerializeField]
    private float healLVL2 = 15f;
    [SerializeField]
    private float healLVL3 = 20f;

    private bool isHealing = false;

    private int lvlOfHeal = 1;

    PlayerHealthManagement healthManagement;

    private float healInterval = 1f; // heal every 1 second
    private float healTimer = 0f;

    private Transform healTransform;

    void Update()
    {
        if (isHealing)
        {
            healTimer += Time.deltaTime;

            if (healTimer >= healInterval)
            {
                healthManagement = GetComponent<PlayerHealthManagement>();
                switch (lvlOfHeal)
                {
                    case 1:
                        healthManagement.Heal(healLVL1);
                        break;
                    case 2:
                        healthManagement.Heal(healLVL2);
                        break;
                    case 3:
                        healthManagement.Heal(healLVL3);
                        break;
                    default:
                        healthManagement.Heal(healLVL3);
                        break;
                }
                if(healthManagement.GetCurrentHealth() > PlayerInfo.maxHealth)
                {
                    //healthManagement.SetHealth(PlayerInfo.maxHealth);
                }
                healTimer = 0f; // reset timer

                healTransform = transform.Find("Healing circle");
                if (healTransform != null)
                {
                    GameObject regenObject = healTransform.gameObject;
                    // Turn it on
                    Debug.Log("Found SelfBurn as child of Player");
                    regenObject.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("SelfBurn object not found as child of Player");
                }
                }
        }
        else
        {
                healTimer = 0f; // reset timer if not healing
        }
    }
    
    public void Heal(int lvl)
    {
        isHealing = true;
        lvlOfHeal = lvl;
    }

    public void StopHeal()
    {
        isHealing = false;
        healTransform = transform.Find("Healing circle");
        if (healTransform != null)
        {
            GameObject regenObject = healTransform.gameObject;
            // Turn it on
            Debug.Log("Found SelfBurn as child of Player");
            regenObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("SelfBurn object not found as child of Player");
        }

    }

}
