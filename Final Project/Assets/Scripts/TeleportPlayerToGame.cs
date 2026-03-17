using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeleportPlayerToGame : MonoBehaviour
{
    private ChangePlayerElement changePlayerElement;
    [SerializeField]
    private GameObject naturePortal;
    [SerializeField]
    private GameObject waterPortal;
    [SerializeField]
    private GameObject firePortal;
    [SerializeField]
    private GameObject earthPortal;
    private GameObject activePortal;

    void Start()
    {
        // Get the ProjectileSpawner component attached to this gameObject
        changePlayerElement = GetComponent<ChangePlayerElement>();
        if (changePlayerElement == null)
        {
            Debug.LogError("changePlayerElement component not found on the GameObject.");
        }

    }
    void OnTriggerEnter(Collider other)
    {
        changePlayerElement.changePlayerTag();
        changePlayerElement.givePlayerAtackElementSpell();
        switch (this.gameObject.name)
        {
            case "Nature":
                ActivatePortal(naturePortal);
                break;
            case "Water":
                ActivatePortal(waterPortal);
                break;
            case "Fire":
                ActivatePortal(firePortal);
                break;
            case "Earth":
                ActivatePortal(earthPortal);
                break;
            default:
                Debug.LogWarning("Unknown portal type: " + this.gameObject.name);
                break;
        }

    }

    private void ActivatePortal(GameObject portal)
    {
        // Deactivate all portals first
        naturePortal.SetActive(false);
        waterPortal.SetActive(false);
        firePortal.SetActive(false);
        earthPortal.SetActive(false);

        // Activate the selected portal
        if (portal != null)
        {
            portal.SetActive(true);
            activePortal = portal;
        }
        else
        {
            Debug.LogWarning("Selected portal is not assigned.");
        }
    }
}
