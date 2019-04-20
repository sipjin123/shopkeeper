using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ShopKeeperAi : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    InventoryManager _inventoryMngr;
    LocationManager _locationMngr;

    [SerializeField]
    private List<AICustomer> _customerList = new List<AICustomer>();

    [SerializeField]
    private List<LootItem> _ItemsToDeliver = new List<LootItem>();

    [SerializeField]
    private ShopKeeperState _ShopKeeperState;
    public void SetAiState(ShopKeeperState state)
    {


    }

    void ProcessCustomer()
    {

        var currentCustomer = _customerList[0];

        _ItemsToDeliver = new List<LootItem>();


        if (_inventoryMngr.CheckIfTheseItemsExist(currentCustomer.PurchaseList))
        {
            _ShopKeeperState = ShopKeeperState.Fetching;
            Debug.LogError("I am FEtching AGain   ");
            _agent.SetDestination(_locationMngr.ShopInventoryLoc.position);
            Debug.LogError("YEs it exist");
        }
        else
        {
            Debug.LogError("Does not exist");
            return;
        }


        foreach (var aw in currentCustomer.PurchaseList)
        {
            string tes = "Order is  : " + aw.name;
           // Debug.LogError(tes);
            _ItemsToDeliver.Add(aw);
        }
    }

    private void Start()
    {
        _ShopKeeperState = ShopKeeperState.Query;
        _inventoryMngr = Factory.Get<InventoryManager>();
        _locationMngr = Factory.Get<LocationManager>();
        AIEventManager.RegisterCustomer.AddListener(_ => 
        {

            _customerList.Add(_);// = _;
            Debug.LogError("Adding Customer : " + _.name+" "+ _customerList.Count);


            if(_ShopKeeperState == ShopKeeperState.Query)
            {
                ProcessCustomer();
            }
        });
        /*
        AIEventManager.QuieryShopItem.AddListener(_ => 
        {
            Debug.LogError("I received List of Order");

            _ItemsToDeliver = new List<LootItem>();


            if (_inventoryMngr.CheckIfTheseItemsExist(_))
            {
                _ShopKeeperState = ShopKeeperState.Fetching;
                _agent.SetDestination(_locationMngr.ShopInventoryLoc.position);
                Debug.LogError("YEs it exist");
            }
            else
            {
                Debug.LogError("Does not exist");
                return;
            }


            foreach (var aw in _)
            {
                string tes = "Order is  : " + aw.name;
                Debug.LogError(tes);
                _ItemsToDeliver.Add(aw);
            }


        });*/
      //  Debug.LogError("I am listening now");
    }

    private void Update()
    {
        if (_ShopKeeperState == ShopKeeperState.Fetching)
        {
            if (Vector3.Distance( _agent.destination,transform.position) < 2)
            {
                _inventoryMngr.DeductItems(_ItemsToDeliver);
                _ShopKeeperState = ShopKeeperState.Looking;
                StartCoroutine(DelayLooking());
            }
        }


        if (_ShopKeeperState == ShopKeeperState.Returning)
        {
            if (Vector3.Distance(_agent.destination, transform.position) < 2)
            {
                _ShopKeeperState = ShopKeeperState.Selling;
                StartCoroutine(DelaySelling());
            }
        }
    }



    IEnumerator DelayLooking()
    {
        yield return new WaitForSeconds(1);
        _ShopKeeperState = ShopKeeperState.Returning;
        _agent.SetDestination(_locationMngr.ShopSellLoc.position);
    }

    IEnumerator DelaySelling()
    {

        yield return new WaitForSeconds(1);
        AIEventManager.RemoveCustomer.Invoke(_customerList[0]);
        _customerList.RemoveAt(0);
        Debug.LogError("I am chekcing if theres anotehr customer : " + _customerList.Count);
        _ShopKeeperState = ShopKeeperState.Query;
        if (_customerList.Count > 0)
        {
            Debug.LogError("There is anotehr custoemr");
            ProcessCustomer();
        }

    }
}
