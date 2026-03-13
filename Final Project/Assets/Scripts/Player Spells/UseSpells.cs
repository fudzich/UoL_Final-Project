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
    public Nature_Field natureField;
    public Earth_SpawnWall spawnWall;
    public Earth_Cone cone;
    public Earth_LaunchBoulder launchBoulder;

    public int igniteLevel = 1; // Set the desired level for Ignite spell
    public int blastLevel = 1; // Set the desired level for Ignite spell
    public int selfBurnLevel = 1; // Set the desired level for Ignite spell
    public int spawnFriendLevel = 1; // Set the desired level for Ignite spell
    public int regenLevel = 1; // Set the desired level for Ignite spell
    public int fieldLevel = 1;
    public int wallLevel = 1;
    public int coneLevel = 1;
    public int launchBoulderLevel = 1;

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

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (natureField != null)
            {
                //Debug.Log("Cast");
                natureField.Field(fieldLevel);
            }
            else
            {
                Debug.LogWarning("Fire_Ignition reference is not set.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (spawnWall != null)
            {
                //Debug.Log("Cast");
                spawnWall.SpawnWall(wallLevel);
            }
            else
            {
                Debug.LogWarning("Fire_Ignition reference is not set.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (cone != null)
            {
                //Debug.Log("Cast");
                cone.SpawnCone(coneLevel);
            }
            else
            {
                Debug.LogWarning("Fire_Ignition reference is not set.");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (launchBoulder != null)
            {
                //Debug.Log("Cast");
                launchBoulder.LaunchBoulder(launchBoulderLevel);
            }
            else
            {
                Debug.LogWarning("Fire_Ignition reference is not set.");
            }
        }
    }
}
