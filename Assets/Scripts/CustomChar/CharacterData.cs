using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CharacterData 
{
    //ui
    public float mana;
    public float maxMana;

    public float health;
    public float maxHealth;
    public float stamina;
    public float maxStamina;
    //movement
    public float[] position;
    //charcustom
    public int curskinIndex , cureyesIndex, curmouthIndex , curhairIndex, curarmourIndex, curClothesIndex;
    public string currentCharName;
    public string[] currentCharRace;

    public int curStrength, curDexterity, curConstitution, curWisdom, curIntelligence, curCharisma;
    public CharacterData(CharcustomScript charcustom )
    {
        //charCustom
        curskinIndex = charcustom.skinIndex;
        cureyesIndex = charcustom.eyesIndex;
        curmouthIndex = charcustom.mouthIndex;
       curhairIndex = charcustom.hairIndex;
        curarmourIndex = charcustom.armourIndex;
        curClothesIndex = charcustom.clothesIndex;

        currentCharRace = charcustom.selectedClass;

        
        curStrength = charcustom.str;
        curDexterity = charcustom.dex;
        curConstitution = charcustom.con;
        curWisdom = charcustom.wis;
        curIntelligence = charcustom.inte;
        curCharisma = charcustom.cha;

        currentCharName = charcustom.charName2;

       

        
    }
   
    public CharacterData(UIBars uiBars)
    {
        //uiBars
        mana = uiBars.curMana;
        maxMana = uiBars.maxMana;

        health = uiBars.curHealth;
        maxHealth = uiBars.maxHealth;

        stamina = uiBars.curStamina;
        maxStamina = uiBars.maxStamina;
    }
}
