using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_SpawnWall : MonoBehaviour
{
    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private float hpLVL1 = 50f;
    [SerializeField]
    private float hpLVL2 = 100f;
    [SerializeField]
    private float hpLVL3 = 150f;

    public void SpawnWall(int lvl)
    {
        Vector3 position = transform.position + transform.forward * 2f;
        Vector3 direction = (transform.position - position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        
        GameObject wall = Instantiate(wallPrefab, position, rotation);
        wall.tag = gameObject.tag;
        
        HealthManagement health = wall.GetComponent<HealthManagement>();

        //Change walls hp based on spells level
        switch (lvl)
        {
            case 1:
                health.maxHealth = hpLVL1;
                break;
            case 2:
                health.maxHealth = hpLVL2;
                break;
            case 3:
                health.maxHealth = hpLVL3;
                break;
            default:
                health.maxHealth = hpLVL3;
                break;
        }
    }
    
}
