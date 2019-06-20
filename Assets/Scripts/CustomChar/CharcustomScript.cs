using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CharcustomScript : MonoBehaviour
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



    public UIBars uiBars;


    [Header("Texture List")]
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();

    [Header("Num")]

    public int skinIndex;
    public int hairIndex, mouthIndex, eyesIndex, armourIndex, clothesIndex;

    [Header("Renderer")]
    public Renderer character;

    [Header("Max Num")]

    public int skinMax;
    public int hairMax, mouthMax, eyesMax, armourMax, clothesMax;
    [Header("Character Name")]
    public InputField charName;
    public string charName2 = "";
    public TextMeshProUGUI ClassName;
    [Header("Stats")]
    public TextMeshProUGUI pointsTXTMesh;
    //class enum
    public CharacterClasss characterClass;
    public string[] statArray = new string[6];
    public int[] stats = new int[6];
    public int[] statsTemp = new int[6];
    public int statsButton;
    public int points = 10;
    public string[] selectedClass = new string[12];
    public int selectedIndex = 0;



    public TextMeshProUGUI StrengthNum, DexterityNum, ConstitutionNum, WisdomNum, IntelligenceNum, CharismaNum;
    public int str, dex, con, wis, inte, cha;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        statArray = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        selectedClass = new string[] { "Borborigan", "Bord", "Cloric", "Drooid", "Foightah", "Moonk", "Poloodoin", "Ronger", "Roogeg", "Soresore_ah", "woolak", "Bizard", };




        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for eyes_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the eyes List
            eyes.Add(temp);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for mouth_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the mouth List
            mouth.Add(temp);
        }
        for (int i = 0; i < hairMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for hair_#
            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the hair List
            hair.Add(temp);
        }
        for (int i = 0; i < armourMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for armour_#
            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the armour List
            armour.Add(temp);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for clothes_#
            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the clothes List
            clothes.Add(temp);
        }
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        SetTexture("skin", skinIndex = 0);
        SetTexture("eyes", eyesIndex = 0);
        SetTexture("mouth", mouthIndex = 0);
        SetTexture("hair", hairIndex = 0);
        SetTexture("armour", armourIndex = 0);
        SetTexture("clothes", clothesIndex = 0);

        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        #endregion
        ChooseClass(selectedIndex);
    }

    private void Update()
    {
        charName2 = charName.text;
        ClassName.text = selectedClass[selectedIndex];
        pointsTXTMesh.text = points.ToString();



        str = stats[0] + statsTemp[0];
        dex = stats[1] + statsTemp[1];
        con = stats[2] + statsTemp[2];
        wis = stats[3] + statsTemp[3];
        inte = stats[4] + statsTemp[4];
        cha = stats[5] + statsTemp[5];


        StrengthNum.text = str.ToString();
        DexterityNum.text = dex.ToString();
        ConstitutionNum.text = con.ToString();
        WisdomNum.text = wis.ToString();
        IntelligenceNum.text = inte.ToString();
        CharismaNum.text = cha.ToString();




    }

    void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        #region Switch Material
        switch (type)
        {
            //case skin
            case "skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skin.ToArray();
                //material index element number is 1
                matIndex = 1;
                break;

            case "eyes":

                index = eyesIndex;

                max = eyesMax;


                textures = eyes.ToArray();

                matIndex = 2;
                break;

            case "mouth":

                index = mouthIndex;

                max = mouthMax;


                textures = mouth.ToArray();

                matIndex = 3;
                break;

            case "hair":

                index = hairIndex;

                max = hairMax;


                textures = hair.ToArray();

                matIndex = 4;
                break;

            case "armour":

                index = armourIndex;

                max = armourMax;


                textures = armour.ToArray();

                matIndex = 5;
                break;

            case "clothes":

                index = clothesIndex;

                max = clothesMax;


                textures = clothes.ToArray();

                matIndex = 6;
                break;

        }

        #endregion
        #region OutSide Switch
        //index plus equals our direction
        //cap our index to loop back around if is is below 0 or above max take one
        //Material array is equal to our characters material list
        //our material arrays current material index's main texture is equal to our texture arrays current index
        //our characters materials are equal to the material array
        //create another switch that is goverened by the same string name of our material
        index += dir;


        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = character.materials;
        mat[matIndex].mainTexture = textures[index];
        character.materials = mat;

        #endregion
        #region Set Material Switch
        //case skin
        switch (type)
        {
            case "skin":
                skinIndex = index;
                break;
            case "eyes":
                eyesIndex = index;
                break;
            case "mouth":
                mouthIndex = index;
                break;
            case "hair":
                hairIndex = index;
                break;
            case "clothes":
                clothesIndex = index;
                break;
            case "armour":
                armourIndex = index;
                break;

        }

        #endregion
    }
    public void Save()
    {
        CharacterSave.SaveCharacter(this);
        CharacterSave.SaveBars(uiBars);
        
    }
    //public void Savebars()
    //{
    //    CharacterSave.SaveBars();
    //}
    public void Play()
    {
       
        SceneManager.LoadScene(1);
    }

    //assign skins with buttons
    #region ButtonSkins
    public void StatAssignSkin(bool a)
    {
        if (a)
        {
            SetTexture("skin", -1);
        }
        else
        {
            SetTexture("skin", +1);
        }
    }
    public void StatAssignEyes(bool a)
    {
        if (a)
        {
            SetTexture("eyes", -1);
        }
        else
        {
            SetTexture("eyes", +1);
        }
    }
    public void StatAssignMouth(bool a)
    {
        if (a)
        {
            SetTexture("mouth", -1);

        }
        else
        {
            SetTexture("mouth", +1);
        }
    }
    public void StatAssignHair(bool a)
    {
        if (a)
        {
            SetTexture("hair", -1);
        }
        else
        {
            SetTexture("hair", +1);
        }
    }
    public void StatAssignArmour(bool a)
    {
        if (a)
        {
            SetTexture("armour", -1);
        }
        else
        {
            SetTexture("armour", +1);
        }
    }
    public void StatAssignClothes(bool a)
    {
        if (a)
        {
            SetTexture("clothes", -1);
        }
        else
        {
            SetTexture("clothes", +1);
        }
    }
    public void ResetChar()
    {
        SetTexture("skin", skinIndex = 0);
        SetTexture("eyes", eyesIndex = 0);
        SetTexture("mouth", mouthIndex = 0);
        SetTexture("hair", hairIndex = 0);
        SetTexture("armour", armourIndex = 0);
        SetTexture("clothes", clothesIndex = 0);
    }
    public void RandomizeChar()
    {
        SetTexture("skin", Random.Range(0, skinMax - 1));
        SetTexture("eyes", Random.Range(0, eyesMax - 1));
        SetTexture("mouth", Random.Range(0, mouthMax - 1));
        SetTexture("hair", Random.Range(0, hairMax - 1));
        SetTexture("armour", Random.Range(0, armourMax - 1));
        SetTexture("clothes", Random.Range(0, clothesMax - 1));
    }
    #endregion
    //assign stats with slider
    #region SliderStats
    public void StrengthButton(bool a)
    {
        statsButton = 0;
        Points(a);
    }
    public void DexterityButton(bool a)
    {
        statsButton = 1;
        Points(a);
    }
    public void ConstitutionButton(bool a)
    {
        statsButton = 2;
        Points(a);
    }
    public void WisdomButton(bool a)
    {
        statsButton = 3;
        Points(a);
    }
    public void IntelligenceButton(bool a)
    {
        statsButton = 4;
        Points(a);
    }
    public void CharismaButton(bool a)
    {
        statsButton = 5;
        Points(a);
    }
    public void Points(bool a)
    {
        if (points > 0)
        {
            if (a == true)
            {
                points--;
                statsTemp[statsButton]++;
                //Debug.Log("increase points");
            }
        }
        if (points < 10 )
        {
            if (a == false && statsTemp[statsButton] > 0)
            {
                points++;
                statsTemp[statsButton]--;

               // Debug.Log("reduce points");
                if (statsTemp[statsButton] < stats[statsButton])
                {

                }
            }  
        }
    }
    #endregion
    //pick class with buttons
    public void ButtonClass(bool a)
    {
        if (a)
        {
            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = selectedClass.Length - 1;
            }
            ChooseClass(selectedIndex);

        }

        else
        {
            selectedIndex++;
            if (selectedIndex > selectedClass.Length - 1)
            {
                selectedIndex = 0;
            }
            ChooseClass(selectedIndex);
        }
    }
    #region ButtonClass
    public void ChooseClass(int className)
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
    #endregion
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