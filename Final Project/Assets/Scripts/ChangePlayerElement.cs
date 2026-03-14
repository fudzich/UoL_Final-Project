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
                PlayerInfo.aquiredSpells[1] = "Water_Beam";
                PlayerInfo.spellsLevel[1] = 1;
                break;
            case "Fire":
                PlayerInfo.aquiredSpells[1] = "Fire_Ignition";
                PlayerInfo.spellsLevel[1] = 1;
                break;
            case "Earth":
                PlayerInfo.aquiredSpells[1] = "Earth_Cone";
                PlayerInfo.spellsLevel[1] = 1;
                break;
            case "Nature":
                PlayerInfo.aquiredSpells[1] = "Nature_SpawnFriend";
                PlayerInfo.spellsLevel[1] = 1;
                break;
        }
    }
}
