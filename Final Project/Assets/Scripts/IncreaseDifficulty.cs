using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDifficulty : MonoBehaviour
{
    [SerializeField]
    private float bias = 5f;
    void Start()
    {
        PlayerInfo.playerBias+=bias;
    }


}
