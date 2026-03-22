using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManagement : MonoBehaviour
{
    [SerializeField] float currentHealth;
    private bool dead = false;

    private PlayerAnimationController playerAnimationController;

    void Start()
    {
        currentHealth = PlayerInfo.maxHealth;
        playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    // Public method to reduce health
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }

    // Public method to increase health
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
    }

    void Update()
    {
        // Check if health is 0 or below
        if (currentHealth <= 0f && !dead)
        {
            currentHealth = 0f;
            dead = true;
            PlayerInfo.gameStart = false;

            PlayerInfo.aquiredSpells = new string[4];
            PlayerInfo.spellsLevel = new int[4];
            PlayerInfo.maxHealth = 100;
            PlayerInfo.dmgIncrease = 1;
            PlayerInfo.playerBias = 0f;

            StartCoroutine(WaitAndChangeScene());
        }
    }

    private System.Collections.IEnumerator WaitAndChangeScene()
    {

        playerAnimationController.PlayerDead();
        // Wait for the animation duration
        yield return new WaitForSeconds(1.666f);
        // Load the first scene
        SceneManager.LoadScene("OpenScene");
    }

    public float GetCurrentHealth(){
        return currentHealth;
    }

    public void SetHealth(float health){
        currentHealth = health;
    }

}
