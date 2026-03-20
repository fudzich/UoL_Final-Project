using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate; // Object to activate when scene is empty

    void Update()
    {
        if (AreAllObjectsCleared())
        {
            if (objectToActivate != null && !objectToActivate.activeSelf)
            {
                objectToActivate.SetActive(true);
                //PlayerInfo.gameStart = false;
            }
        }
    }

    private bool AreAllObjectsCleared()
    {
        // Get all root objects in the scene
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if the object's tag is NOT in ignored tags
            if ((obj.tag == "Nature" || obj.tag == "Water" || obj.tag == "Earth" || obj.tag == "Fire") && obj.tag != PlayerInfo.tag)
            {
                // If object is active, scene isn't cleared yet
                if (obj.activeInHierarchy)
                    return false;
            }
        }
        // No non-ignored objects found
        return true;
    }
}
