using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerElement : MonoBehaviour
{

    [SerializeField] private string newElementTag;
    // Start is called before the first frame update
    public void changePlayerTag()
    {
        PlayerInfo.tag = newElementTag;
    }
}
