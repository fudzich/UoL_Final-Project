using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSpells : MonoBehaviour
{
    public Fire_Ignition fireIgnition; // Reference to the Fire_Ignition component
    public Fire_Blast fireBlast;
    public Fire_SelfBurn fireSelfBurn;
    public Nature_SpawnFriend natureSpawnFriend;

    public Nature_Regen natureRegen;
    public int igniteLevel = 1; // Set the desired level for Ignite spell
    public int blastLevel = 1; // Set the desired level for Ignite spell
    public int selfBurnLevel = 1; // Set the desired level for Ignite spell
    public int spawnFriendLevel = 1; // Set the desired level for Ignite spell
     public int regenLevel = 1; // Set the desired level for Ignite spell

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (fireIgnition != null)
            {
                //Debug.Log("Cast");
                fireIgnition.Ignite(igniteLevel);
            }
            else
            {
                Debug.LogWarning("Fire_Ignition reference is not set.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (fireBlast != null)
            {
                //Debug.Log("Cast");
                fireBlast.Blast(blastLevel);
            }
            else
            {
                Debug.LogWarning("Fire_Ignition reference is not set.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (fireSelfBurn != null)
            {
                //Debug.Log("Cast");
                fireSelfBurn.SelfBurn(selfBurnLevel);
            }
            else
            {
                Debug.LogWarning("Fire_Ignition reference is not set.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (natureSpawnFriend != null)
            {
                //Debug.Log("Cast");
                natureSpawnFriend.SpawnFriend(spawnFriendLevel);
            }
            else
            {
                Debug.LogWarning("Fire_Ignition reference is not set.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (natureRegen != null)
            {
                //Debug.Log("Cast");
                natureRegen.Regen(regenLevel);
            }
            else
            {
                Debug.LogWarning("Fire_Ignition reference is not set.");
            }
        }
    }
}
