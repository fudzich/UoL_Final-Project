using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] float currentHealth;

    [SerializeField]
    private GameObject damageBar; // Assign the prefab in the inspector
    [SerializeField]
    private float heightOffset = 3f; // Base height above the object
    private float randomnessRange = 0.5f; // How much randomness to add

    void Start()
    {
        //Increase health for enemies in later arenas
        if(gameObject.tag != PlayerInfo.tag)
            currentHealth = maxHealth+PlayerInfo.playerBias;
        else
            currentHealth = maxHealth;
    }

    // Public method to reduce health
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if(damageBar != null)
            InstantiateDamageNumber(damageAmount);

    }

    void Update()
    {
        // Destroy object if the health is 0 or below 
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

    //Show recieved damage in the scene
    private void InstantiateDamageNumber(float damage)
    {
        // Calculate random offset
        float randomX = Random.Range(-randomnessRange, randomnessRange);
        float randomZ = Random.Range(-randomnessRange, randomnessRange);
        
        // Set the position above the current object with randomness
        Vector3 spawnPosition = new Vector3(
            transform.position.x + randomX,
            transform.position.y + heightOffset,
            transform.position.z + randomZ
        );

        // Instantiate the object
        GameObject newObject = Instantiate(damageBar, spawnPosition, damageBar.transform.rotation);
        TMP_Text textComponent = newObject.GetComponentInChildren<TMP_Text>();
        textComponent.text = damage.ToString();
    }
}
