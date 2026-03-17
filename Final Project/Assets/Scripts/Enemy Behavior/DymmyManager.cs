using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DymmyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    // Update is called once per frame
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
