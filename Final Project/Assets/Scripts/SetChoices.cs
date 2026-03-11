using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChoices : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> firstPortalList;

    [SerializeField]
    private List<GameObject> secondPortalList;

    private string secondChosenPortalName;

    private ActivateRandomPortal portalActivator;

    void Awake()
    {
        portalActivator = GetComponent<ActivateRandomPortal>();

        if (portalActivator == null)
        {
            Debug.LogError("ActivateRandomPortal component not found on this GameObject.");
            return;
        }

        // First call with no excludeName (pass null or empty string)
        string firstChosen = portalActivator.ChooseAndActivatePortal(firstPortalList, "");

        // Second call with the second list, excluding the first chosen portal
        secondChosenPortalName = portalActivator.ChooseAndActivatePortal(secondPortalList, firstChosen);
    }
}
