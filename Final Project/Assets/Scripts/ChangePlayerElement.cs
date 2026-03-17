using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangePlayerElement : MonoBehaviour
{

    [SerializeField] private string newElementTag;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    public void changePlayerTag()
    {
        PlayerInfo.tag = newElementTag;
        player.tag = PlayerInfo.tag;
    }

    public void givePlayerAtackElementSpell()
    {
        switch (newElementTag)
        {
            case "Water":
                PlayerInfo.aquiredSpells[0] = "Water_Tornado";
                PlayerInfo.spellsLevel[0] = 1;
                break;
            case "Fire":
                PlayerInfo.aquiredSpells[0] = "Fire_Ignition";
                PlayerInfo.spellsLevel[0] = 1;
                break;
            case "Earth":
                PlayerInfo.aquiredSpells[0] = "Earth_LaunchBoulder";
                PlayerInfo.spellsLevel[0] = 1;
                break;
            case "Nature":
                PlayerInfo.aquiredSpells[0] = "Nature_SpawnFriend";
                PlayerInfo.spellsLevel[0] = 1;
                break;
        }
    }

    public void givePlayerSpell(string spell)
    {
        if (Array.IndexOf(PlayerInfo.aquiredSpells, spell) >= 0)
        {
            int index = Array.IndexOf(PlayerInfo.aquiredSpells, spell);
            PlayerInfo.spellsLevel[index]+=1;
        }
        else
        {
            int nextFreeIndex = -1;

            for (int i = 0; i < PlayerInfo.aquiredSpells.Length; i++)
            {
                if (string.IsNullOrEmpty(PlayerInfo.aquiredSpells[i]))
                {
                    nextFreeIndex = i;
                    break; // exit loop once the first free cell is found
                }
            }

            PlayerInfo.aquiredSpells[nextFreeIndex] = spell;
            PlayerInfo.spellsLevel[nextFreeIndex] = 1;
        }
    }
}
