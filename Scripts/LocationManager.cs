using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{

    [SerializeField] private Transform _ShopSellLoc, _ShopInventoryLoc, _ShopBuyLoc;

    public void Awake()
    {
        Factory.Register<LocationManager>(this);
    }


}
