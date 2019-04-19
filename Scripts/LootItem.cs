using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : ScriptableObject
{
    [SerializeField]
    private LootType _LootType;

    public string ItemName;
    public LootType LootType
    {
        get { return _LootType; }
    }

}
