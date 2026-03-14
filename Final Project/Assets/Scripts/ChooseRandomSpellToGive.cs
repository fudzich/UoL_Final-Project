using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomSpellToGive : MonoBehaviour
{
    [SerializeField]
    private List<string> spells;
    // Start is called before the first frame update
    
    // Call this method when you want to assign a spell
    public void AssignRandomSpell()
    {
        if (spells == null || spells.Count == 0)
        {
            Debug.LogWarning("Spell list is empty!");
            return;
        }

        int maxAttempts = spells.Count;
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            string randomSpell = spells[Random.Range(0, spells.Count)];
            int index = System.Array.IndexOf(PlayerInfo.aquiredSpells, randomSpell);

            if (index != -1)
            {
                // Spell already acquired
                int currentLevel = PlayerInfo.spellsLevel[index];
                if (currentLevel < 3)
                {
                    PlayerInfo.spellsLevel[index] = currentLevel + 1;
                    Debug.Log($"Increased level of {randomSpell} to {currentLevel + 1}");
                    return;
                }
                else
                {
                    // Spell is max level, try another
                    continue;
                }
            }
            else
            {
                // Spell is new, find a free slot
                int freeIndex = -1;
                for (int i = 0; i < PlayerInfo.aquiredSpells.Length; i++)
                {
                    if (string.IsNullOrEmpty(PlayerInfo.aquiredSpells[i]))
                    {
                        freeIndex = i;
                        break;
                    }
                }

                if (freeIndex != -1)
                {
                    PlayerInfo.aquiredSpells[freeIndex] = randomSpell;
                    PlayerInfo.spellsLevel[freeIndex] = 1; // Starting level
                    Debug.Log($"Added new spell {randomSpell} at index {freeIndex}");
                    return;
                }
                else
                {
                    Debug.LogWarning("No free slot for new spell!");
                    return;
                }
            }
        }

        Debug.Log("Could not find a new spell to add or upgrade after max attempts.");
    }

    
}
