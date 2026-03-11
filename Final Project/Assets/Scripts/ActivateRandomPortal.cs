using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRandomPortal : MonoBehaviour
{
    public string ChooseAndActivatePortal(List<GameObject> objects, string excludeName)
    {
        // Filter out the object with the excludeName
        List<GameObject> validObjects = objects.FindAll(obj => obj != null && obj.name != excludeName);

        if (validObjects.Count == 0)
        {
            Debug.LogWarning("No valid objects to choose from after excluding: " + excludeName);
            return null;
        }

        // Randomly select one object from the valid list
        int randomIndex = Random.Range(0, validObjects.Count);
        GameObject chosenObject = validObjects[randomIndex];

        // Activate the chosen object
        chosenObject.SetActive(true);

        // Return the name of the chosen object
        return chosenObject.name;
    }
}
