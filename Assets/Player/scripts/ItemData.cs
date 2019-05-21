
using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
//stored data for items
        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;
        int heal = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;

        //switch for item ID for all items
        switch(itemID)
        {

        }
        Item temp = new Item
        {
            Name = name,
            Description = description,
            ID = itemID,
            Value = value,
            Icon = Resources.Load("Prefabs/"+icon)as Texture2D,
            Mesh = Resources.Load("Prefabs/"+mesh)as GameObject,
            Heal = heal,
            Damage = damage,
            Armour = armour,
            Amount = amount,
            Type = type,
        };
        return temp;
    }
}
