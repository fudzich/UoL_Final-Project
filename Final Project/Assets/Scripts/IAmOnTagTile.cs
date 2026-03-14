using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmOnTagTile : MonoBehaviour
{
    [SerializeField]
    private string tagName;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInfo.isOnTile = tagName;
    }
}
