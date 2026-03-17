using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInfo
{
    public static string tag;
    public static int kills;

    public static int maxHealth = 100;

    public static bool gameStart = false;

    public static float dmgIncrease = 1;

    public static string isOnTile;

    public static float playerBias = 0f;

    public static string[] aquiredSpells = new string[4];
    public static int[] spellsLevel = new int[4];


    public static string[] savedSpellsState = new string[4];
    public static int[] savedLevelState = new int[4];
}
