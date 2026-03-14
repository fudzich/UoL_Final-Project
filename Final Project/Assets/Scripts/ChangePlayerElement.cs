using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerElement : MonoBehaviour
{

    [SerializeField] private string newElementTag;
    // Start is called before the first frame update
    public void changePlayerTag()
    {
        PlayerInfo.tag = newElementTag;
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
}
