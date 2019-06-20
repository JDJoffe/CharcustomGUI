using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class CharacterSave
{
    //save charcustom
    public static void SaveCharacter(CharcustomScript charcustom)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SavesChar.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        CharacterData charData = new CharacterData(charcustom);
       
        formatter.Serialize(stream, charData);
       
        stream.Close();
    }
   
    //save health
    public static void SaveBars(UIBars uiBars)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SavesBars.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        CharacterData barData = new CharacterData(uiBars);

        formatter.Serialize(stream, barData);

        stream.Close();
    }
    //load customchar
    public static CharacterData LoadCharacter()
    {
        string path = Application.persistentDataPath + "/SavesChar.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            CharacterData charData = formatter.Deserialize(stream) as CharacterData;         
            stream.Close();
            return charData;                    
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
   
    //load Bars
    public static CharacterData LoadBars()
    {
        string path = Application.persistentDataPath + "/SavesBars.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            CharacterData barData = formatter.Deserialize(stream) as CharacterData;
            stream.Close();
            return barData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
