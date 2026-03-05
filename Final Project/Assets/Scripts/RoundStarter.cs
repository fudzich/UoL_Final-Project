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

            GameObject playerObject = GameObject.Find("Player");
            playerObject.tag = "Water";

            if (enemySpawner != null)
            {
                enemySpawner.SpawnEnemies();
                hasStarted = true; // Ensure it only runs once
            }
        }
    }
}
