using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nature_Field : MonoBehaviour
{
    [SerializeField]
    private float dmgLVL1 = 2f;
    [SerializeField]
    private float dmgLVL2 = 4f;
    [SerializeField]
    private float dmgLVL3 = 8f;

    [SerializeField]
    private GameObject field;
    

    public void Field(int lvl)
    {
        if (field != null)
        {
            GameObject newObject = Instantiate(field, transform.position, Quaternion.identity);
            newObject.tag = gameObject.tag; // Give spell players tag
            FloorIsIvy floorIsIvy = newObject.GetComponent<FloorIsIvy>();
            if (floorIsIvy != null)
            {
                //change damage based on spell level
                switch (lvl)
                    {
                        case 1:
                            floorIsIvy.damage = dmgLVL1 * PlayerInfo.dmgIncrease;
                            break;
                        case 2:
                            floorIsIvy.damage = dmgLVL2 * PlayerInfo.dmgIncrease;
                            break;
                        case 3:
                            floorIsIvy.damage = dmgLVL3 * PlayerInfo.dmgIncrease;
                            break;
                        default:
                            floorIsIvy.damage = dmgLVL3 * PlayerInfo.dmgIncrease;
                            break;
                    }
            }
            else
            {
                Debug.LogWarning("The instantiated object does not have a BlastDamage component.");
            }
        }
        else
        {
            Debug.LogWarning("Effect Prefab is not set.");
        }
    }
}
