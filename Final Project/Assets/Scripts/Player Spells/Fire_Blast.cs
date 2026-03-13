using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Blast : MonoBehaviour
{
    [SerializeField]
    private float dmgLVL1 = 50f;
    [SerializeField]
    private float dmgLVL2 = 100f;
    [SerializeField]
    private float dmgLVL3 = 200f;



    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private float selfDamage = 10f;
    PlayerHealthManagement healthManagement;

    public void Blast(int lvl)
    {
        //Debug.Log("BLAST");
        if (effectPrefab != null)
        {
            // Define the height offset
            float heightOffset = 0.5f; // change this value as needed
            // Instantiate the object at a higher position
            GameObject newObject = Instantiate(effectPrefab, new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z), Quaternion.identity);
            newObject.tag = gameObject.tag;
            BlasDamage blastDamage = newObject.GetComponent<BlasDamage>();
            if (blastDamage != null)
            {
                switch (lvl)
                    {
                        case 1:
                            blastDamage.damage = dmgLVL1 * PlayerInfo.dmgIncrease;
                            break;
                        case 2:
                            blastDamage.damage = dmgLVL2 * PlayerInfo.dmgIncrease;
                            break;
                        case 3:
                            blastDamage.damage = dmgLVL3 * PlayerInfo.dmgIncrease;
                            break;
                        default:
                            blastDamage.damage = dmgLVL3 * PlayerInfo.dmgIncrease;
                            break;
                    }
            }
            else
            {
                Debug.LogWarning("The instantiated object does not have a BlastDamage component.");
            }

            healthManagement = GetComponent<PlayerHealthManagement>();
            healthManagement.TakeDamage(selfDamage);
        }
        else
        {
            Debug.LogWarning("Effect Prefab is not set.");
        }
    }

}
