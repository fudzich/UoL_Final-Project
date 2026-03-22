using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAmOnTagTile : MonoBehaviour
{
    [SerializeField]
    private string tagName;

    private void OnTriggerEnter(Collider other)
    {
        //Check what tile the player is standing on
        if(other.name == "Player")
            PlayerInfo.isOnTile = tagName;
    }
}
