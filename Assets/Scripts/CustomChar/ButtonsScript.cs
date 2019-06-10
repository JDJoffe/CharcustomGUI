using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonsScript : MonoBehaviour
{

    #region Sounds
    public AudioClip button;
    public AudioSource buttonSource;

    public void PlaySound()
    {
        buttonSource.clip = button;
        buttonSource.Play();
    }
    #endregion

    #region Variables



    [Header("Texture List")]
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();

    [Header("Num")]

    public int skinIndex, hairIndex, mouthIndex, eyesIndex, armourIndex, clothesIndex;

    [Header("Renderer")]
    public Renderer character;

    [Header("Max Num")]

    public int skinMax, hairMax, mouthMax, eyesMax, armourMax, clothesMax;
    [Header("Character Name")]
    public Text charName;
    public string charName2 = "";
    [Header("Stats")]
    //class enum
    public CharacterClasss characterClass;
    public string[] statArray = new string[6];
    public int[] stats = new int[6];
    public int[] statsTemp = new int[6];
    public int points = 10;
    public string[] selectedClass = new string[12];
    public int selectedIndex = 0;

    #endregion
    private void Awake()
    {
        charName = GameObject.Find("EnteredName").GetComponent<Text>();
        charName2 = charName.text;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        statArray = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        selectedClass = new string[] { "Borborigan", "Bord", "Cloric", "Drooid", "Foightah", "Moonk", "Poloodoin", "Ronger", "Roogeg", "Soresore_ah", "woolak", "Bizard", };


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Save()
    {

    }
    public void Play()
    {
        Save();
        SceneManager.LoadScene(1);
    }
    public void StatAssign()
    {

    }

    void ChooseClass(int className)
    {
        switch (className)
        {
            /// <summary>
            /// remember to change stats of each class 
            /// </summary>
            case 0:
                stats[0] = 15; //strength
                stats[1] = 10; //ew dex
                stats[2] = 10; // constitution
                stats[3] = 10; // wisdom
                stats[4] = 10; //intelligence
                stats[5] = 5; //charisma
                characterClass = CharacterClasss.Borborigan;
                break;
            case 1:
                stats[0] = 5;
                stats[1] = 10;
                stats[2] = 5;
                stats[3] = 10;
                stats[4] = 15;
                stats[5] = 15;
                characterClass = CharacterClasss.Bord;
                break;
            case 2:
                stats[0] = 5;
                stats[1] = 5;
                stats[2] = 10;
                stats[3] = 15;
                stats[4] = 15;
                stats[5] = 10;
                characterClass = CharacterClasss.Cloric;
                break;
            case 3:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Drooid;
                break;
            case 4:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Foightah;
                break;
            case 5:
                stats[0] = 10;
                stats[1] = 15;
                stats[2] = 10;
                stats[3] = 15;
                stats[4] = 5;
                stats[5] = 5;
                characterClass = CharacterClasss.Moonk;
                break;
            case 6:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Poloodoin;
                break;
            case 7:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Ronger;
                break;
            case 8:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Roogeg;
                break;
            case 9:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Soresore_ah;
                break;
            case 10:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.woolak;
                break;
            case 11:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                characterClass = CharacterClasss.Bizard;
                break;

        }
    }
}
public enum CharacterClasss
{
    Borborigan,
    Bord,
    Cloric,
    Drooid,
    Foightah,
    Moonk,
    Poloodoin,
    Ronger,
    Roogeg,
    Soresore_ah,
    woolak,
    Bizard,

}
