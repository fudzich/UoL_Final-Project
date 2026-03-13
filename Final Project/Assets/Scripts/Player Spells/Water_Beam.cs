using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Beam : MonoBehaviour
{
    public GameObject beamPrefab;
    public LayerMask targetLayer; // Layer for objects to detect with collider

    private GameObject beamInstance;
    private LineRenderer lineRenderer;
    private Collider beamCollider;

    [SerializeField]
    private float dmgLVL1 = 10f;
    [SerializeField]
    private float dmgLVL2 = 15f;
    [SerializeField]
    private float dmgLVL3 = 20f;

    void Update()
    {
        if (beamInstance != null)
        {
            // Start point is the player's position
            Vector3 startPoint = transform.position;

            // Calculate target point
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.origin + ray.direction * 100f;
            }

            // Update line renderer
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, targetPoint);

            // Update collider to match beam from startPoint to targetPoint
            UpdateCollider(startPoint, targetPoint);
        }
    }

    public void FireBeam(int lvl)
    {
        beamInstance = Instantiate(beamPrefab);
        lineRenderer = beamInstance.GetComponent<LineRenderer>();
        beamCollider = beamInstance.GetComponent<Collider>();

        beamInstance.tag = gameObject.tag;
        TornadoDamage tornadoDamage = beamInstance.GetComponent<TornadoDamage>();
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

    void UpdateCollider(Vector3 start, Vector3 end)
    {
        if (beamCollider is CapsuleCollider capsule)
        {
            Vector3 direction = end - start;
            float length = direction.magnitude;

            // Set position at the midpoint between start and end
            capsule.transform.position = (start + end) / 2f;

            // Set the height of the capsule to match the distance
            capsule.height = length;

            // Set the capsule's local axis to Y (default)
            capsule.direction = 1;

            // Rotate the capsule to align with the direction
            if (length > 0)
            {
                capsule.transform.rotation = Quaternion.LookRotation(direction);
            }

            // Set radius
            capsule.radius = 0.2f; // Adjust as needed
        }
        else if (beamCollider is BoxCollider box)
        {
            Vector3 midPoint = (start + end) / 2;
            box.center = transform.InverseTransformPoint(midPoint);
            box.size = new Vector3(0.2f, 0.2f, Vector3.Distance(start, end));
            box.transform.rotation = Quaternion.LookRotation(end - start);
        }
    }

    public void StopBeam()
    {
        if (beamInstance != null)
            Destroy(beamInstance);
    }
}
