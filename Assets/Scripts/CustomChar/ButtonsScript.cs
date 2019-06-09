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
    public Renderer character ;
    [Header("Max Num")]    
    public int skinMax, hairMax, mouthMax, eyesMax, armourMax, clothesMax;
    [Header("Character Name")]  
    public Text charName;
    public string charName2 = "";
    [Header("Stats")]
    //class enum
    public CharacterClass characterClass;
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
        statArray = new string[] { "Strength", "Dex builds yuck", "Constitution", "Wisdom", "Intelligence", "Charisma" };
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
}
