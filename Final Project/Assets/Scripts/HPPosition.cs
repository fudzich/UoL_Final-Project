using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPosition : MonoBehaviour
{
    Vector3 offset;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move hp with player
        transform.position = player.transform.position + offset;
    }
}
