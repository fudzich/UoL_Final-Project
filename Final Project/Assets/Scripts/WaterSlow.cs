using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSlow : MonoBehaviour
{

    //Slow down no water element objects
    private void OnTriggerStay(Collider other)
    {
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

    //Stop slow when object leave water
    private void OnTriggerExit(Collider other)
    {
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
