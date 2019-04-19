using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomizerManager : MonoBehaviour
{
    [SerializeField]
    private ItemListData _ItemListData;

    [SerializeField]
    private int _MinLoot = 3;
    [SerializeField]
    private int _MaxLoot = 10;
    private int _RandomizedLoot;

    [SerializeField]
    private int _MinRarity = 1;

    [SerializeField]
    private int _MaxRarity = 10;


    public void RequestRandomizedLoot()
    {
        _RandomizedLoot = Random.Range(_MinLoot, _MaxLoot);


    }

    void Update()
    {
        
    }
}
