using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpBarHandler : MonoBehaviour
{
    public GameObject player;
    //private float health;
    private PlayerHealthManagement healthManagement;
    private TMP_Text text;
    void Start()
    {
        healthManagement = player.GetComponent<PlayerHealthManagement>();
        text = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        float health = healthManagement.GetCurrentHealth();
        text.text = health.ToString();

        if(health < 30f)
        {
            text.color = Color.red;
        }
    }
}
