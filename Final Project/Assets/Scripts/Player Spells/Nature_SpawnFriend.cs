using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nature_SpawnFriend : MonoBehaviour
{

    [SerializeField]
    private GameObject rangedFriend;
    [SerializeField]
    private GameObject meleeFriend;
    [SerializeField]
    private Material materialPrefab;

    public void SpawnFriend(int lvl)
    {
        // Determine spawn position in front of this object
        Vector3 basePosition = transform.position + transform.forward * 2f;
        float spawnOffset = 2f;

        switch (lvl)
        {
            case 1:
                // Spawn 1 ranged friend
                SpawnFriend(rangedFriend, basePosition);
                break;
            case 2:
                // Spawn 1 ranged and 1 melee
                SpawnFriend(rangedFriend, basePosition);
                SpawnFriend(meleeFriend, basePosition + new Vector3(spawnOffset, 0, 0));
                break;
            case 3:
                // Spawn 2 ranged and 2 melee
                SpawnFriend(rangedFriend, basePosition);
                SpawnFriend(rangedFriend, basePosition + new Vector3(spawnOffset, 0, 0));
                SpawnFriend(meleeFriend, basePosition + new Vector3(0, 0, spawnOffset));
                SpawnFriend(meleeFriend, basePosition + new Vector3(spawnOffset, 0, spawnOffset));
                break;
            default:
                Debug.LogWarning("Invalid level provided");
                break;
        }
    }

    private void SpawnFriend(GameObject friendPrefab, Vector3 position)
    {
        GameObject newFriend = Instantiate(friendPrefab, position, Quaternion.identity);

        if (friendPrefab == rangedFriend)
        {
            // Apply material to "AutumnYe07" child
            Transform childTransform = newFriend.transform.Find("AutumnYe07");
            if (childTransform != null)
            {
                Renderer renderer = childTransform.GetComponent<Renderer>();
                if (renderer != null && materialPrefab != null)
                {
                    renderer.material = materialPrefab;
                }
                else
                {
                    Debug.LogWarning("Renderer or MaterialPrefab missing on 'AutumnYe07'");
                }
            }
            else
            {
                Debug.LogWarning("Child 'AutumnYe07' not found in ranged friend");
            }
        }
        else if (friendPrefab == meleeFriend)
        {
            // Apply material to "Cylinder" child
            Transform childTransform = newFriend.transform.Find("Cylinder");
            if (childTransform != null)
            {
                Renderer renderer = childTransform.GetComponent<Renderer>();
                if (renderer != null && materialPrefab != null)
                {
                    renderer.material = materialPrefab;
                }
                else
                {
                    Debug.LogWarning("Renderer or MaterialPrefab missing on 'Cylinder'");
                }
            }
            else
            {
                Debug.LogWarning("Child 'Cylinder' not found in melee friend");
            }
        }

        // Set the tag to match this object
        newFriend.tag = this.tag;
    }

}
