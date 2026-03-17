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
    //public LayerMask interactableLayer;

    private GameObject tornado;

    public void Update()
    {
        // If there's an active tornado, update its position to follow the mouse
        if (tornado != null)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Move the tornado to the hit point
                tornado.transform.position = hit.point;
                //tornado.transform.localScale = Vector3.one;
                //tornado.transform.rotation = Quaternion.identity;
                //float moveSpeed =  5f;
                //tornado.transform.position = Vector3.Lerp(tornado.transform.position, hit.point, Time.deltaTime * moveSpeed);
                //Vector3 scaleT = new Vector3(3.40021634f,3.40021729f,3.11041689f);
                //tornado.transform.localScale = scaleT;
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
            //tornado.transform.localScale = Vector3.one;
            //tornado.transform.rotation = Quaternion.identity;
        }
        if (tornado != null)
        {
            tornado.tag = gameObject.tag;

            TornadoDamage tornadoDamage = tornado.GetComponent<TornadoDamage>();
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
