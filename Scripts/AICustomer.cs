using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AICustomer : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    private Transform _ShopEntry;

    private BehaviorState _behavior;

    public void Init(Transform trans)
    {
        _ShopEntry = trans;
    }

    private void Start()
    {

    }

}
