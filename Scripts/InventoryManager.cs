using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory _Inventory;

    void Awake()
    {
        Factory.Register<InventoryManager>(this);
    }


    public bool CheckIfTheseItemsExist(List<LootItem> loots)
    {
        foreach (var item in loots)
        {
            if(!_Inventory.RawItems.Exists(_=>  _.Item == item ))
            {
                return false;
            }
            else
            {
                var temp = _Inventory.RawItems.Find(_ => _.Item == item);
                if(temp.Quantity  < 1)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void DeductItems(List<LootItem> loots)
    {

        foreach (var item in loots)
        {
            var temp = _Inventory.RawItems.Find(_ => _.Item == item);
            if (temp.Quantity > 0)
            {
                temp.Quantity -= 1;
               // Debug.LogError(temp.Item.name + " Has been reduced by 1");
            }
        }
    }
}
