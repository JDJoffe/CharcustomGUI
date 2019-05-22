using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Var
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public static int money;

    //screen H and W
    public Vector2 scr;
    //scroll bar
    public Vector2 scrollPos;
    //sort items into their types
    public string[] sortType = new string[7];
    public int index;
    public string sortingType = "All";
    //drop in worldspace
    public Transform dropLocation;
    public Transform[] equippedLocation;
    /*
     * 0= right hand
     * 1= head
     * 
     */
    public GameObject curWeapon;
    public GameObject curHelm;

    #endregion
    void Start()
    {
        sortType = new string[] {"All", "Food", "Weapon", "Apparel", " Crafting", "Quest", "Money", " Ingredients", " Potions", " Scrolls" };

        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(302));

        for (int i = 0; i < inv.Count; i++) { Debug.Log(inv[1].Name); }

    }
    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Movement.canMove = true;
            return false;
        }
        else
        {
            //screen rez
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.canMove = false;
            return true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //if(!PauseMenu.isPaused)
            ToggleInv();
        }
    }
    void DisplayInv(string sortType)
    {
        
        if (!(sortType == "All" || sortType == ""))
        {
            #region Types
            //convert the sortType to our ItemType
            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
            //amount of that type
            int a = 0;
            //slot position of GUI item
            int s = 0;

            for (int i = 0; i < inv.Count; i++)
            {
                //find our types
                if (inv[i].Type == type)
                {
                    //increases the amount of this type
                    a++;
                }
            }

            //if the amount of this type is less or equal to the amount we can display on screen without scrolling
            if (a <= 34)
            {
                //filter through all items
                for (int i = 0; i < inv.Count; i++)
                {
                    //if its the type we want to display
                    if (inv[i].Type == type)
                    {
                        //display a button that is of this type and slot under the lsat one
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        //increase the slot pos so the next one slides under
                        s++;
                    }
                }
            }
            //if have more than amount viewable items 
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((a - 34) * (0.25f * scr.y))), true, true);

                #region Items in Viewing Area
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        //display a button that is of this type and slot under the lsat one
                        if (GUI.Button(new Rect(0 * scr.x, 0 * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        //increase the slot pos so the next one slides under
                        s++;
                    }
                }
                #endregion
                GUI.EndScrollView();
            }
            #endregion 
        }
        //if we display everything
        else
        {
            scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count- 34) * (0.25f * scr.y))), true, true);

            #region Items in Viewing Area
            for (int i = 0; i < inv.Count; i++)
            {
                    //display a button that is of this type and slot under the lsat one
                    if (GUI.Button(new Rect(0 * scr.x, 0 * scr.y + i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                    //increase the slot pos so the next one slides under
            }
            #endregion
            GUI.EndScrollView();
        }
    }

    private void OnGUI()
    {
        //if(!PauseMenu.isPaused)
        if (showInv)
        {
            //put inventory here haha heehee
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            for (int i = 0; i < sortType.Length; i++)
            {
                if (GUI.Button(new Rect(5.5f* scr.x + i * (scr.x), 0.25f * scr.y, scr.x, 0.25f * scr.y),sortType[i]))
                {
                    sortingType = sortType[i];
                }
            }
            DisplayInv(sortingType);
            if (selectedItem !=null)
            {
                GUI.DrawTexture(new Rect(11 * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon);
            }
        }
    }
}
