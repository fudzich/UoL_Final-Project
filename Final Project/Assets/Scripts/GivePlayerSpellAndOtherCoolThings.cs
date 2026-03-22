using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePlayerSpellAndOtherCoolThings : MonoBehaviour
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

    [SerializeField]
    private GameObject natureTile;
    [SerializeField]
    private GameObject waterTile;
    [SerializeField]
    private GameObject fireTile;
    [SerializeField]
    private GameObject earthTile;
    private GameObject activeTile;
    public string spellToGive;
    [SerializeField]
    private StartRogueScene startRogueScene;

    // Start is called before the first frame update
    void Start()
    {
        changePlayerElement = GetComponent<ChangePlayerElement>();
        if (changePlayerElement == null)
        {
            Debug.LogError("changePlayerElement component not found on the GameObject.");
        }
    }

    void OnTriggerEnter(Collider other)
    {   
        startRogueScene.RefreshSpellsArrays();

        changePlayerElement.changePlayerTag();
        changePlayerElement.givePlayerSpell(spellToGive);
        
        switch (this.gameObject.name)
        {
            case "Nature":
                ActivatePortal(naturePortal);
                ActivateTile(natureTile);
                break;
            case "Water":
                ActivatePortal(waterPortal);
                ActivateTile(waterTile);
                break;
            case "Fire":
                ActivatePortal(firePortal);
                ActivateTile(fireTile);
                break;
            case "Earth":
                ActivatePortal(earthPortal);
                ActivateTile(earthTile);
                break;
            default:
                Debug.LogWarning("Unknown portal type: " + this.gameObject.name);
                break;
        }

        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            // Get the CastSpells component
            CastSpells castSpellsComponent = playerObject.GetComponent<CastSpells>();
            
            if (castSpellsComponent != null)
            {
                // Call the CheckListOfSpells method
                castSpellsComponent.CheckListOfSpells();
            }
            else
            {
                Debug.LogError("CastSpells component not found on Player object.");
            }
        }
        else
        {
            Debug.LogError("Player object not found in the scene.");
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

    private void ActivateTile(GameObject tile)
    {
        // Deactivate all portals first
        natureTile.SetActive(false);
        waterTile.SetActive(false);
        fireTile.SetActive(false);
        earthTile.SetActive(false);

        // Activate the selected portal
        if (tile != null)
        {
            tile.SetActive(true);
            activeTile = tile;
        }
        else
        {
            Debug.LogWarning("Selected portal is not assigned.");
        }
    }
}
