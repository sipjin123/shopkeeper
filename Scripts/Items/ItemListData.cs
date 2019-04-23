using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListData : ScriptableObject
{
    public List<LootItem> LootableItem;
    public List<LootItem> WeaponItems;
    public List<LootItem> ArmorItems;
}
