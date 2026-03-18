using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZControl : MonoBehaviour
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
        Vector3 newPosition = transform.position;
        newPosition.z = player.transform.position.z + offset.z;
        transform.position = newPosition;
    }
}
