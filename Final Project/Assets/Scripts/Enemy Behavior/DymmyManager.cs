using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DymmyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    void Update()
    {
        CheckPlayerTag();
    }

    public void CheckPlayerTag()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is not assigned.");
            return;
        }
        
        //Chang tag so player would be able to damagae dummy
        switch (player.tag)
        {
            case "Water":
                gameObject.tag = "Fire";
                break;
            case "Earth":
                gameObject.tag = "Fire";
                break;
            case "Fire":
                gameObject.tag = "Water";
                break;
            case "Nature":
                gameObject.tag = "Fire";
                break;
            default:
                gameObject.tag = "Fire";
                break;
        }
    }
}
