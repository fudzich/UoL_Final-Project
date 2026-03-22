using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [SerializeField] 
    private GameObject firstText;
    [SerializeField] 
    private GameObject secondText;

    private void OnTriggerEnter(Collider other)
    {

        // Activate the second text
        if (secondText != null)
        {
            secondText.SetActive(true);
        }
        // Deactivate the first text
        if (firstText != null)
        {
            firstText.SetActive(false);
        }

    }
}
