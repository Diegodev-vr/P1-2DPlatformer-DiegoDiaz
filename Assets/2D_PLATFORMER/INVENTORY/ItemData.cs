using UnityEngine;
///// enumerations for every type of item in the game, this will be used to identify items in the inventory and in the item database
public enum ItemType
{
    None,
    Potion,
    Sword,
    Shield
}
///// this struct will hold the data for each item type, such as its name, icon, and value.
///// This will be used in the item database to store the information for each item type,
///// and can be referenced by the inventory and other systems that need to access item data.
[System.Serializable]
public struct ItemData
{
    ///// the type of the item, this will be used as a key to look up the item data in the item database
    public ItemType type;
    ///// the name of the item, this will be displayed in the UI when the player picks up the item or uses it
    public string name;
    ///// the icon of the item, this will be displayed in the inventory UI to represent the item visually
    public Sprite icon;
    ///// the value of the item, this can be used for various purposes such as determining how much points 
    ///// the player gets when picking up the item, or how much health the player restores when using a potion
    public int value;
}
