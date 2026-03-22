using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{

    [SerializeField]
    public float speed = 25f;


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
