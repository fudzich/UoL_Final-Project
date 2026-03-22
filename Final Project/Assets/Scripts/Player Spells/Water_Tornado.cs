using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Tornado : MonoBehaviour
{
    [SerializeField]
    private float dmgLVL1 = 20f;
    [SerializeField]
    private float dmgLVL2 = 30f;
    [SerializeField]
    private float dmgLVL3 = 40f;

    [SerializeField]
    private GameObject tornadoPrefab;

    private GameObject tornado;

    public void Update()
    {
        // If there's an active tornado, update its position to follow the mouse
        if (tornado != null)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                tornado.transform.position = hit.point;
            }
        }
    }

    public void CastTornado(int lvl)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            tornado = Instantiate(tornadoPrefab, hit.point, Quaternion.identity);
        }
        if (tornado != null)
        {
            tornado.tag = gameObject.tag;

            TornadoDamage tornadoDamage = tornado.GetComponent<TornadoDamage>();
            //Change spell damage based on its level
            switch (lvl)
            {
                case 1:
                    tornadoDamage.damage = dmgLVL1 * PlayerInfo.dmgIncrease;
                    break;
                case 2:
                    tornadoDamage.damage = dmgLVL2 * PlayerInfo.dmgIncrease;
                    break;
                case 3:
                    tornadoDamage.damage = dmgLVL3 * PlayerInfo.dmgIncrease;
                    break;
                default:
                    tornadoDamage.damage = dmgLVL3 * PlayerInfo.dmgIncrease;
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Failed to instantiate tornado prefab.");
        }
    }

    public void StopTornado()
    {
        if (tornado != null)
        {
            Destroy(tornado);
        }
    }
}
