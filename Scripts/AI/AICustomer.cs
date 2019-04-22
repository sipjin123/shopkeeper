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

    private float _HitDistanceMagnitude = 4;

    [SerializeField] private Transform _CanvasLooker;
    [SerializeField] private Camera _cam;
    public void Init(Transform trans)
    {
        _ShopEntry = trans;
    }


    public void Init()
    {
        Arrive();
    }

    private void Start()
    {
        _cam = Camera.main;
        _CanvasLooker.gameObject.SetActive(false);
        Arrive();

        AIEventManager.RemoveCustomer.AddListener(_ => 
        {
            if(_ == this)
            {
                Debug.LogError("I remove myself");
                _agent.SetDestination(Factory.Get<LocationManager>().AIExitLocation.position);
                _behavior = BehaviorState.Exit;
                _CanvasLooker.gameObject.SetActive(false);
            }
        });

    }

    private void Arrive()
    {
        _behavior = BehaviorState.Arrival;
        StartCoroutine(QueryAction());


        //RANDOMIZE PURCAHSE LSIT HERE
        _LootText.text = "";
        foreach (var item in _PurchaseList)
            _LootText.text += item.name + "\n";
    }

    public void ProcessShoping()
    {
        _CanvasLooker.gameObject.SetActive(true);
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
            if (Vector3.Distance(_agent.destination, transform.position) < _HitDistanceMagnitude)
            {
                AIEventManager.QuieryShopItem.Invoke(_PurchaseList);
                _behavior = BehaviorState.Order;
                Debug.LogError("Query");
                AIEventManager.RegisterCustomer.Invoke(this);
            }
        }

        if (_behavior == BehaviorState.Exit)
        {
            if (Vector3.Distance(_agent.destination, transform.position) < _HitDistanceMagnitude)
            {
                //Arrive();
                AddToPool();
            }
        }
    }

    void AddToPool()
    {
        Factory.Get<AICustomerManager>().AddToPool(this);
        gameObject.SetActive(false);
    }
}
