using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] protected float lifetime = 1f;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
