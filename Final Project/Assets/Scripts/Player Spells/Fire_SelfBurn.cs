using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_SelfBurn : MonoBehaviour
{
    [SerializeField]
    private float dmgIncLVL1 = 0.5f;
    [SerializeField]
    private float dmgIncLVL2 = 1f;
    [SerializeField]
    private float dmgIncLVL3 = 1.5f;

    [SerializeField]
    private float selfDamage = 1f;
    
    private bool isBurn = false;

    PlayerHealthManagement healthManagement;

    private float damageInterval = 1f; // damage every 1 second
    private float damageTimer = 0f;

    void Update()
    {
        if (isBurn)
    {
        damageTimer += Time.deltaTime;

        if (damageTimer >= damageInterval && healthManagement.GetCurrentHealth() - selfDamage > 1)
        {
            healthManagement.TakeDamage(selfDamage);
            damageTimer = 0f; // reset timer
        }
        }
        else
        {
            damageTimer = 0f; // reset timer if not burning
        }
    }
    
    public void SelfBurn(int lvl)
    {
        if (!isBurn)
        {
            isBurn = true;
            
            healthManagement = GetComponent<PlayerHealthManagement>();
            
            //Change Damage increase based on level
            switch (lvl)
            {
                case 1:
                    PlayerInfo.dmgIncrease += dmgIncLVL1;
                    break;
                case 2:
                    PlayerInfo.dmgIncrease += dmgIncLVL2;
                    break;
                case 3:
                    PlayerInfo.dmgIncrease += dmgIncLVL3;
                    break;
                default:
                    PlayerInfo.dmgIncrease += dmgIncLVL3;
                    break;
            }

            Transform selfBurnTransform = transform.Find("Buff");
            if (selfBurnTransform != null)
            {
                GameObject selfBurnObject = selfBurnTransform.gameObject;
                // Turn it on
                selfBurnObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("SelfBurn object not found as child of Player");
            }
        }
    }

    public void StopBurn()
    {
        PlayerInfo.dmgIncrease = 0;
        isBurn = false;
    }
}
