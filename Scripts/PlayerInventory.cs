using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : ScriptableObject
{
    [SerializeField]
    private Dictionary<LootItem, int> _RawItems = new Dictionary<LootItem, int>();

    [SerializeField] private List<LootItemInventory> _rawItems;
    public List<LootItemInventory> RawItems { get { return _rawItems; } }

    [SerializeField, Header("EditorOnly")]
    public LootItem ItemToAdd;
    [SerializeField, Header("EditorOnly")]
    public int AmountToAdd;

    
}
[Serializable]
public class LootItemInventory
{
    public string ItemName;
    public LootItem Item;
    public int Quantity;
}