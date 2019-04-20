using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AICustomer : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    private Transform _ShopEntry;

    private BehaviorState _behavior;

    [SerializeField]
    private List<LootItem> _PurchaseList = new List<LootItem>();

    public List<LootItem> PurchaseList { get { return _PurchaseList; } }

    [SerializeField] private Text _LootText;

    [SerializeField] private Transform _CanvasLooker;
    [SerializeField] private Camera _cam;
    public void Init(Transform trans)
    {
        _ShopEntry = trans;
    }



    private void Start()
    {
        _cam = Camera.main;
        _behavior = BehaviorState.Arrival;
        StartCoroutine(QueryAction());
        _LootText.text = "";
        foreach (var item in _PurchaseList)
            _LootText.text += item.name + "\n";
        AIEventManager.RemoveCustomer.AddListener(_ => 
        {
            if(_ == this)
            {
                Debug.LogError("I remove myself");
                _agent.SetDestination(Factory.Get<LocationManager>().AIExitLocation.position);
            }
        });

    }

    IEnumerator QueryAction()
    {
        yield return new WaitForSeconds(2);
        _behavior = BehaviorState.GoSHop;
        _agent.SetDestination(Factory.Get<LocationManager>().ShopBuyLoc.position);
    }

    private void Update()
    {
        _CanvasLooker.LookAt( _cam.transform.position);



        if (_behavior == BehaviorState.GoSHop)
        {
            if(_agent.hasPath == false)
            {
                AIEventManager.QuieryShopItem.Invoke(_PurchaseList);
                _behavior = BehaviorState.Order;
                Debug.LogError("Query");
                AIEventManager.RegisterCustomer.Invoke(this);
            }
        }

    }
}
