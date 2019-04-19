using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class AIEventManager 
{
    static AIMovementManager _AIMovemanager;
    public static UnityEvent QuieryShopItem = new UnityEvent();

    public static void Init(AIMovementManager aiMngr)
    {
        _AIMovemanager = aiMngr;
    }

}
