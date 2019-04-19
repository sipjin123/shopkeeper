using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : ScriptableObject
{
    public string tet = "";
    [SerializeField]
    private Dictionary<LootItem, int> _RawItems = new Dictionary<LootItem, int>();
    [SerializeField]
    private Dictionary<CombinableItem, int> _EquipmentItems = new Dictionary<CombinableItem, int>();

    public Dictionary<LootItem, int> RawItems { get; set; }

    public Dictionary<CombinableItem, int> EquipmentItems { get; set; }


    [SerializeField, Header("EditorOnly")]
    public LootItem ItemToAdd;
    [SerializeField, Header("EditorOnly")]
    public int AmountToAdd;

    [SerializeField, Header("EditorOnly")]
    public CombinableItem CombinableItemToAdd;
}
