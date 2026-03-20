using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToRogueScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player"){
            PlayerInfo.gameStart = false;
            SceneManager.LoadScene("SpellChoice");
        }
        
    }
}
