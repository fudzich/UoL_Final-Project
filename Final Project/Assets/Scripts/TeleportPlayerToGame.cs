using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPlayerToGame : MonoBehaviour
{
    private ChangePlayerElement changePlayerElement;
    //[SerializeField] 
    //private GameObject portalPrefab;

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
        SceneManager.LoadScene("SampleScene");
        //if (portalPrefab != null)
        //{
        //    Instantiate(portalPrefab, transform.position, Quaternion.identity);
        //}
    }
}
