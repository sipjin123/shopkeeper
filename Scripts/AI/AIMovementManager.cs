using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AIMovementManager : MonoBehaviour
{


    [SerializeField] NavMeshAgent 
        _ShopKeeper,
        _Smithy,
        _Bartender,
        _Scrapmaster,
        _Looter;


    private void Awake()
    {
        AIEventManager.Init(this);
    }

    private void Update()
    {
        
    }


}
