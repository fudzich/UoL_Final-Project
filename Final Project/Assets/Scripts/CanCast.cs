using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanCast : MonoBehaviour
{
    private  Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        // Get the active scene
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScene.name != "SampleScene")
        {
            PlayerInfo.canCast = true;
        }
        else if (currentScene.name == "SampleScene" && PlayerInfo.gameStart == true)
        {
            PlayerInfo.canCast = true;
        }
        else
        {
            PlayerInfo.canCast = false;
        }
    }
}
