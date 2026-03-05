using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Serialized enemy prefabs for each combination
    [SerializeField] private GameObject earth_melee;
    [SerializeField] private GameObject fire_melee;
    [SerializeField] private GameObject nature_melee;
    [SerializeField] private GameObject water_melee;
    [SerializeField] private GameObject earth_ranged;
    [SerializeField] private GameObject fire_ranged;
    [SerializeField] private GameObject nature_ranged;
    [SerializeField] private GameObject water_ranged;

    // Number of enemies to spawn around each Tower/Bastion
    [SerializeField] private int numberOfEnemies = 3;

    // Radius of spawn circle around each object
    [SerializeField] private float spawnRadius = 2f;

    // Method to spawn enemies based on scene objects
    public void SpawnEnemies()
    {
        // Find all objects named "Tower"
        GameObject[] towers = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in towers)
        {
            if (obj.name == "Tower")
            {
                string tag = obj.tag;

                // Determine which enemy to spawn based on tag
                GameObject enemyPrefab = null;

                switch (tag)
                {
                    case "Fire":
                        enemyPrefab = fire_melee;
                        break;
                    case "Water":
                        enemyPrefab = water_melee;
                        break;
                    case "Nature":
                        enemyPrefab = nature_melee;
                        break;
                    case "Earth":
                        enemyPrefab = earth_melee;
                        break;
                }

                if (enemyPrefab != null)
                {
                    SpawnEnemiesAround(obj, enemyPrefab);
                }
            }
        }

        // Find all objects named "Bastion"
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.name == "Bastion")
            {
                string tag = obj.tag;

                // Determine which ranged enemy to spawn based on tag
                GameObject rangedEnemyPrefab = null;

                switch (tag)
                {
                    case "Fire":
                        rangedEnemyPrefab = fire_ranged;
                        break;
                    case "Water":
                        rangedEnemyPrefab = water_ranged;
                        break;
                    case "Nature":
                        rangedEnemyPrefab = nature_ranged;
                        break;
                    case "Earth":
                        rangedEnemyPrefab = earth_ranged;
                        break;
                }

                if (rangedEnemyPrefab != null)
                {
                    SpawnEnemiesAround(obj, rangedEnemyPrefab);
                }
            }
        }
    }

    // Helper method to spawn enemies in a circle around a position
    private void SpawnEnemiesAround(GameObject centerObject, GameObject enemyPrefab)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float angle = i * Mathf.PI * 2f / numberOfEnemies; // evenly spaced angles
            Vector3 spawnPos = centerObject.transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * spawnRadius;
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
