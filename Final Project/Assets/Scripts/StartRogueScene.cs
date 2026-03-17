using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRogueScene : MonoBehaviour
{
    [SerializeField]
    public List<string> fireSpells;
    [SerializeField]
    public List<string> waterSpells;
    [SerializeField]
    public List<string> earthSpells;
    [SerializeField]
    public List<string> natureSpells;

    private List<string> removedSpells;

    private bool isFull = false;

    private ActivateSpellChoices activateSpellChoices;
    
    // Start is called before the first frame update
    void Start()
    {
        removedSpells = new List<string>();
        activateSpellChoices = gameObject.GetComponent<ActivateSpellChoices>();
        saveArrayState();

        CheckFullAquiredSpells();
        CheckAllSpellLists();

        if (isFull)
        {
            ChooseRandomAcquiredSpell(1);
            ChooseRandomAcquiredSpell(2);
        }
        else
        {
            ChooseRandomSpell(1);
            ChooseRandomSpell(2);
        }
    }
    private void saveArrayState()
    {
        for (int i = 0; i < PlayerInfo.aquiredSpells.Length; i++)
        {
            PlayerInfo.savedSpellsState[i] = PlayerInfo.aquiredSpells[i];
            PlayerInfo.savedLevelState[i] = PlayerInfo.spellsLevel[i];
        }
    }

    public void RefreshSpellsArrays()
    {
        for (int i = 0; i < PlayerInfo.aquiredSpells.Length; i++)
        {
            PlayerInfo.aquiredSpells[i] = PlayerInfo.savedSpellsState[i];
            PlayerInfo.spellsLevel[i] = PlayerInfo.savedLevelState[i];
        }
    }

    private void CheckFullAquiredSpells()
    {
        // Check if aquiredSpells array is full (no empty strings)
        isFull = true;
        foreach (var spell in PlayerInfo.aquiredSpells)
        {
            if (string.IsNullOrEmpty(spell))
            {
                isFull = false;
                break;
            }
        }

        if (isFull)
        {
            Debug.Log("aquiredSpells array is full. Listing spells and their lists:");
            for (int i = 0; i < PlayerInfo.aquiredSpells.Length; i++)
            {
                string spellName = PlayerInfo.aquiredSpells[i];
                string listName = FindSpellInLists(spellName);
                Debug.Log($"Spell: {spellName}, List: {listName}");
            }
        }
    }

    private string FindSpellInLists(string spellName)
    {
        if (fireSpells.Contains(spellName))
            return "Fire";
        if (waterSpells.Contains(spellName))
            return "Water";
        if (earthSpells.Contains(spellName))
            return "Earth";
        if (natureSpells.Contains(spellName))
            return "Nature";
        return "Unknown";
    }

    private void CheckAllSpellLists()
    {
        CheckSpellList(fireSpells, "Fire");
        CheckSpellList(waterSpells, "Water");
        CheckSpellList(earthSpells, "Earth");
        CheckSpellList(natureSpells, "Nature");
    }

    private void CheckSpellList(List<string> spellList, string listName)
    {
        int totalSpells = spellList.Count;
        int acquiredCount = 0;
        bool allAtMaxLevel = true;

        for (int i = 0; i < PlayerInfo.aquiredSpells.Length; i++)
        {
            string acquiredSpell = PlayerInfo.aquiredSpells[i];
            int spellLevel = PlayerInfo.spellsLevel[i];

            if (spellList.Contains(acquiredSpell))
            {
                acquiredCount++;
                if (spellLevel == 3)
                {
                    // Add to removedSpells if at max level
                    if (!removedSpells.Contains(acquiredSpell))
                    {
                        removedSpells.Add(acquiredSpell);
                        Debug.Log($"Added {acquiredSpell} to removedSpells list (max level).");
                    }
                }
                else if (spellLevel < 3)
                {
                    allAtMaxLevel = false;
                }
            }
        }

        if (acquiredCount == totalSpells && totalSpells != 0 && allAtMaxLevel)
        {
            Debug.Log($"All {listName} spells are acquired and at max level!");
        }
        else
        {
            Debug.Log($"{listName} spells acquired: {acquiredCount}/{totalSpells}. All max level: {allAtMaxLevel}");
        }
    }

    private void ChooseRandomSpell(int number)
    {
        // Combine all spell lists into one
        List<string> allSpells = new List<string>();
        allSpells.AddRange(fireSpells);
        allSpells.AddRange(waterSpells);
        allSpells.AddRange(earthSpells);
        allSpells.AddRange(natureSpells);

        // Remove spells that are in removedSpells
        foreach (string removedSpell in removedSpells)
        {
            allSpells.Remove(removedSpell);
        }

        if (allSpells.Count == 0)
        {
            Debug.Log("No spells available to select.");
            return;
        }

        // Select a random spell
        int randomIndex = Random.Range(0, allSpells.Count);
        string selectedSpell = allSpells[randomIndex];

        // Find which list it belongs to
        string elementName = FindSpellInLists(selectedSpell);

        //Remove it to not generate again
        removedSpells.Add(selectedSpell);
        activateSpellChoices.ActivateSpellChoice(selectedSpell, elementName, number);
        Debug.Log($"Randomly selected spell: {selectedSpell} from list: {elementName}");
    }

    private void ChooseRandomAcquiredSpell(int number)
    {
        // Collect all spells that are less than level 3
        List<string> underleveledSpells = new List<string>();
        for (int i = 0; i < PlayerInfo.aquiredSpells.Length; i++)
        {
            string spell = PlayerInfo.aquiredSpells[i];
            int level = PlayerInfo.spellsLevel[i];

            if (!string.IsNullOrEmpty(spell) && level < 3)
            {
                underleveledSpells.Add(spell);
            }
        }

        if (underleveledSpells.Count == 0)
        {
            Debug.Log("No underleveled spells found.");
            return;
        }

        // Randomly select an underleveled spell
        int randomIndex = Random.Range(0, underleveledSpells.Count);
        string selectedSpell = underleveledSpells[randomIndex];

        string elementName = FindSpellInLists(selectedSpell);
         activateSpellChoices.ActivateSpellChoice(selectedSpell, elementName, number);
        Debug.Log($"Randomly selected underleveled spell: {selectedSpell}");
    }
}
