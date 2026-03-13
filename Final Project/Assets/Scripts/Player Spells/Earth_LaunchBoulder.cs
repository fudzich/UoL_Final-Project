using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_LaunchBoulder : MonoBehaviour
{
    [SerializeField]
    private int triggerCountLVL1 = 2;
    [SerializeField]
    private int triggerCountLVL2 = 3;
    [SerializeField]
    private int triggerCountLVL3 = 4;

    [SerializeField]
    private float speedLVL1 = 10f;
    [SerializeField]
    private float speedLVL2 = 15f;
    [SerializeField]
    private float speedLVL3 = 20f;




    [SerializeField]
    private GameObject boulderPrefab;

    public void LaunchBoulder(int lvl)
    {
        //Debug.Log("BLAST");
        if (boulderPrefab != null)
        {
            Vector3 spawnPosition = transform.position + transform.forward * 1f; // offset in front
            GameObject boulder = Instantiate(boulderPrefab, spawnPosition, transform.rotation);
            boulder.tag = gameObject.tag;
            
            BulletFly bulletSpeed = boulder.GetComponent<BulletFly>();
            BoulderDamage  boulderTriggerCunt = boulder.GetComponent<BoulderDamage>();

            switch (lvl)
            {
                case 1:
                    bulletSpeed.speed = speedLVL1;
                    boulderTriggerCunt.maxTriggerCounters = triggerCountLVL1;
                    break;
                case 2:
                    bulletSpeed.speed = speedLVL2;
                    boulderTriggerCunt.maxTriggerCounters = triggerCountLVL2;
                    break;
                case 3:
                    bulletSpeed.speed = speedLVL3;
                    boulderTriggerCunt.maxTriggerCounters = triggerCountLVL3;
                    break;
                default:
                    bulletSpeed.speed = speedLVL3;
                    boulderTriggerCunt.maxTriggerCounters = triggerCountLVL3;
                    break;
            }

        }
        else
        {
            Debug.LogWarning("Effect Prefab is not set.");
        }
    }
}
