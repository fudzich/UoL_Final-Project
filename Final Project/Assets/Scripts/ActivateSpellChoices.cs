using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpellChoices : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> firstPortalList;

    [SerializeField]
    private List<GameObject> secondPortalList;
    
    public void ActivateSpellChoice(string spellName, string element, int choice)
    {
        List<GameObject> targetList;
        if (choice == 1)
        {
            targetList = firstPortalList;
        }
        else if (choice == 2)
        {
            targetList = secondPortalList;
        }
        else
        {
            Debug.LogWarning("Invalid choice value: " + choice);
            return;
        }

        GameObject portal = targetList.Find(p => p.name == element);
        if (portal != null)
        {
            portal.SetActive(true);
            portal.GetComponent<GivePlayerSpellAndOtherCoolThings>().spellToGive = spellName;
        }
        else
        {
            Debug.LogWarning("Portal with name " + element + " not found in firstPortalList.");
        }
    }
}
