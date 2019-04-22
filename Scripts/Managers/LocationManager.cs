using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{

    [SerializeField] public Transform ShopSellLoc, ShopInventoryLoc, ShopBuyLoc, AIExitLocation;

    public void Awake()
    {
        Factory.Register<LocationManager>(this);
    }


}
