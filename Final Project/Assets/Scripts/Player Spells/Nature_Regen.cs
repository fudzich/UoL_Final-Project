using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nature_Regen : MonoBehaviour
{
    [SerializeField]
    private float healLVL1 = 2f;
    [SerializeField]
    private float healLVL2 = 4f;
    [SerializeField]
    private float healLVL3 = 8f;

    private bool isHealing = false;

    private int lvlOfRegen = 1;

    PlayerHealthManagement healthManagement;

    private float healInterval = 1f; // heal every 1 second
    private float healTimer = 0f;

    void Update()
    {
        if (isHealing)
        {
            healTimer += Time.deltaTime;

            if (healTimer >= healInterval)
            {
                healthManagement = GetComponent<PlayerHealthManagement>();
                switch (lvlOfRegen)
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
                    healthManagement.SetHealth(PlayerInfo.maxHealth);
                }
                healTimer = 0f; // reset timer
            }
        }
        else
        {
                healTimer = 0f; // reset timer if not healing
        }
    }
    
    public void Regen(int lvl)
    {
        if (!isHealing)
        {
            isHealing = true;
            lvlOfRegen = lvl;
        }
    }
}
