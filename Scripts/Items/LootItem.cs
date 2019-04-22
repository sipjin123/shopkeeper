using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : ScriptableObject
{
    [SerializeField]
    private LootType _LootType;

    public string ItemName;

    public int Rarity;

    public LootType LootType
    {
        get { return _LootType; }
    }

    [SerializeField]
    private List<LootItem> _RequiredCombination;
    public List<LootItem> RequiredCombination { get { return _RequiredCombination; } }


}
