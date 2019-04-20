using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class AIEventManager 
{
    static AIMovementManager _AIMovemanager;
    public static UnityEvent<List<LootItem>> QuieryShopItem = new LootItemEvent();

    public static UnityEvent<AICustomer> RegisterCustomer = new CustomerEvent();
    public static UnityEvent<AICustomer> RemoveCustomer = new CustomerEvent();

    public static void Init(AIMovementManager aiMngr)
    {
        _AIMovemanager = aiMngr;
    }

}
