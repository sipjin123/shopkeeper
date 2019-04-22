using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICustomerManager : MonoBehaviour
{
    [SerializeField]
    List<AICustomer> _AvailableCustomers = new List<AICustomer>();
    [SerializeField]
    List<AICustomer> _DeployedCustomers = new List<AICustomer>();

    [SerializeField]
    private GameObject _aiCustoemr;

    [SerializeField]
    private List<Transform> _SpawnPoints;

    private void Awake()
    {
        Factory.Register<AICustomerManager>(this);
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.X))
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                SpawnACustomer();
            }
        }
    }

    void SpawnACustomer()
    {
        if(_AvailableCustomers.Count == 0)
        {
            int randomSpawner = Random.RandomRange(0, _SpawnPoints.Count - 1);
            GameObject temp = Instantiate(_aiCustoemr, _SpawnPoints[randomSpawner].position, Quaternion.identity) as GameObject;
            _AvailableCustomers.Add(temp.GetComponent<AICustomer>());
        }

        AICustomer spawnedAi = _AvailableCustomers[0];
        spawnedAi.gameObject.SetActive(true);
        spawnedAi.Init();
        _DeployedCustomers.Add(spawnedAi);


        _AvailableCustomers.RemoveAt(0);
    }

    public void AddToPool(AICustomer aiObj)
    {
        _DeployedCustomers.Remove(aiObj);
        _AvailableCustomers.Add(aiObj);
    }
}
