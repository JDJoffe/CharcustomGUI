using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CharacterData : CharcustomScript
{


    public int curskinIndex , cureyesIndex, curmouthIndex , curhairIndex, curarmourIndex, curClothesIndex;
    public string currentCharName;
    public string[] currentCharRace;
    public int[] currentCharData;
    public int[] currentCharStats;
    public CharacterData(CharcustomScript charcustom)
    {
        curskinIndex = skinIndex;
        cureyesIndex = eyesIndex;
        curmouthIndex = mouthIndex;
       curhairIndex = hairIndex;
        curarmourIndex = armourIndex;
        curClothesIndex = clothesIndex;

        currentCharRace = selectedClass;

        currentCharStats[0] = str;
        currentCharStats[1] = dex;
        currentCharStats[2] = con;
        currentCharStats[3] = wis;
        currentCharStats[4] = inte;
        currentCharStats[5] = cha;

        currentCharName = charName2;

    }
}
