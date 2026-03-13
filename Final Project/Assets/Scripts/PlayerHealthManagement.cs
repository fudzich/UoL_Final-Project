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

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
    }

    void Update()
    {
        // Check if health is 0 or below
        if (currentHealth <= 0f && !dead)
        {
            //Debug.Log("AU");
            dead = true;
            PlayerInfo.gameStart = false;
            StartCoroutine(WaitAndChangeScene());
        }
    }

    private System.Collections.IEnumerator WaitAndChangeScene()
    {

        playerAnimationController.PlayerDead();
        // Wait for the animation duration (0.833 seconds)
        yield return new WaitForSeconds(1.666f);
        // Load the specified scene
        SceneManager.LoadScene("OpenScene");
    }

    public float GetCurrentHealth(){
        return currentHealth;
    }

    public void SetHealth(float health){
        currentHealth = health;
    }

}
