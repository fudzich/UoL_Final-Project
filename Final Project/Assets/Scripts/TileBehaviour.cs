using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{

    public GameObject[] towers; // 0 - No tower 1 - Sphere tower 2 - Cube tower

    public void UpdateTile(bool[] status)
    {
        for(int i = 0; i < status.Length; i++)
        {
            towers[i].SetActive(status[i]);
        }
    }
}
