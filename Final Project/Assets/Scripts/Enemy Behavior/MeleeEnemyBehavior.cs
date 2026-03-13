using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehavior : MonoBehaviour
{
    [SerializeField] private float focusDistance = 10f;
    [SerializeField] private List<string> targetTags;
    [SerializeField] private float attackDistance = 2f; // Distance to trigger slash attack
    [SerializeField] private float moveSpeed = 3f; // Speed at which the enemy moves toward the target
     private float attackRate = 1f; // How often it can attack
    private float attackTimer = 0f;
    private SlashSpawner slashSpawner;
    //private Rigidbody rb;

    [SerializeField]
    private float speedSlower = 0f;

    void Start()
    {
        slashSpawner = GetComponent<SlashSpawner>();
        if (slashSpawner == null)
        {
            Debug.LogError("SlashSpawner component not found on the Enemy.");
        }

        string objTag = gameObject.tag; // Get the tag of the object
        // Check if the tag exists in the list
        if (targetTags.Contains(objTag))
        {
            // Remove the tag from the list
            targetTags.Remove(objTag);
            //Debug.Log($"Removed tag {objTag} from the list.");
        }

    }

    void Update()
    {
        // Update the attack cooldown timer
        attackTimer += Time.deltaTime;

        GameObject target = null;
        float closestDistance = Mathf.Infinity;

        // Find the Player first
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distToPlayer <= focusDistance)
            {
                if (targetTags.Contains(player.tag))
                {
                    target = player;
                    closestDistance = distToPlayer;
                }
            }
        }

        // Check other objects if player not prioritized
        if (target == null)
        {
            Debug.Log("I don't see player");
            foreach (string tag in targetTags)
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject obj in objects)
                {
                    if (obj.name == "Bullet(Clone)") // ignoring bullets
                        continue;

                    if (obj.name == "Slash(Clone)") // ignoring bullets
                        continue;

                    float dist = Vector3.Distance(transform.position, obj.transform.position);
                    if (dist < closestDistance)
                    {
                        target = obj;
                        closestDistance = dist;
                    }
                }
            }
        }

        //Debug.Log("I exist");
        // If a target is found, move towards it
       // If a target is found, move towards it
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position);
            direction.y = 0f; // prevent vertical movement/rotation
            float distance = direction.magnitude;

            // Move closer if not within attack distance
            if (distance > attackDistance)
            {
                // Move towards the target
                Vector3 moveDirection = direction.normalized;
                transform.position += moveDirection * (moveSpeed - speedSlower) * Time.deltaTime;

                // Rotate to face the target
                if (moveDirection != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 15f);
                }
            }
            else
            {
                // Close enough to attack
                if (attackTimer >= attackRate)
                {
                    if (slashSpawner != null)
                    {
                        slashSpawner.SpawnSlash();
                    }
                    attackTimer = 0f; // reset cooldown
                }
            }
        }
    }

    public void ModifySpeed()
    {
        speedSlower = moveSpeed / 2;
    }

    public void ResetSpeed()
    {
        speedSlower = 0f;
    }
    
}
