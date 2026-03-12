using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructAfterDelay : MonoBehaviour
{
    [SerializeField]
    private float delaySeconds = 2f; // Time to wait before destruction

    private void Start()
    {
        // Start the coroutine to wait and then destroy
        StartCoroutine(DestroyAfterDelay());
    }

    private System.Collections.IEnumerator DestroyAfterDelay()
    {
        // Wait for the specified amount of seconds
        yield return new WaitForSeconds(delaySeconds);

        // Destroy this game object
        Destroy(gameObject);
    }
}
