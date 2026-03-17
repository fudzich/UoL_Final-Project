using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySpellChanges : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < PlayerInfo.aquiredSpells.Length; i++)
        {
            PlayerInfo.aquiredSpells[i] = PlayerInfo.savedSpellsState[i];
            PlayerInfo.spellsLevel[i] = PlayerInfo.savedLevelState[i];
        }
    }
}
