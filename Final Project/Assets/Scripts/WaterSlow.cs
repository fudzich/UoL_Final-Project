using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSlow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ahoy");
        if (other.gameObject.tag != "Water")
        {
            if(other.name == "Player")
            {
                var movement = other.GetComponent<PlayerMovement>();
                if (movement != null)
                {
                    movement.ModifySpeed();
                }
            }
            else
            {
                var movement = other.GetComponent<MeleeEnemyBehavior>();
                if (movement != null)
                {
                    movement.ModifySpeed();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Hoya");
        if (other.gameObject.tag != "Water")
        {
            if(other.name == "Player")
            {
                var movement = other.GetComponent<PlayerMovement>();
                if (movement != null)
                {
                    movement.ResetSpeed();
                }
            }
            else
            {
                var movement = other.GetComponent<MeleeEnemyBehavior>();
                if (movement != null)
                {
                    movement.ResetSpeed();
                }
            }
        }
    }
}
