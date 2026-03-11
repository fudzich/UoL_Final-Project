using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStarter : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private bool hasStarted = false;

    void Start()
    {
        // Get the EnemySpawner component from the same GameObject
        enemySpawner = GetComponent<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.LogError("EnemySpawner component not found on this GameObject.");
        }
    }

    void Update()
    {
        if (!hasStarted && Input.GetKeyDown(KeyCode.Y))
        {
            PlayerInfo.gameStart = true;

            GameObject playerObject = GameObject.Find("Player");

            if (PlayerInfo.tag != null)
            {
                playerObject.tag = PlayerInfo.tag;
            }
            else
            {
                PlayerInfo.tag = "Water";
                playerObject.tag = PlayerInfo.tag;
            }

            if (enemySpawner != null)
            {
                enemySpawner.SpawnEnemies();
                hasStarted = true; // Ensure it only runs once
            }
        }
    }
}
