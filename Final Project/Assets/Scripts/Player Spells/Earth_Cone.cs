using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Cone : MonoBehaviour
{
    [SerializeField]
    private GameObject conePrefab;

    [SerializeField]
    private float dmgLVL1 = 80f;
    [SerializeField]
    private float dmgLVL2 = 160f;
    [SerializeField]
    private float dmgLVL3 = 300f;
    
    public void SpawnCone(int lvl)
    {
        Vector3 spawnPosition = transform.position + transform.forward * 1f; // offset in front
        
        GameObject cone = Instantiate(conePrefab, spawnPosition, transform.rotation);
        cone.tag = gameObject.tag;

        SlashBehavior coneDMG = cone.GetComponent<SlashBehavior>();
        switch (lvl)
        {
            case 1:
                coneDMG.meleeDamage = dmgLVL1 * PlayerInfo.dmgIncrease;
                break;
            case 2:
                coneDMG.meleeDamage = dmgLVL2 * PlayerInfo.dmgIncrease;
                break;
            case 3:
                coneDMG.meleeDamage = dmgLVL3 * PlayerInfo.dmgIncrease;
                break;
            default:
                coneDMG.meleeDamage = dmgLVL3 * PlayerInfo.dmgIncrease;
                break;
        }
    }
}
