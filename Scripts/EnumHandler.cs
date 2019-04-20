using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumHandler
{

}



public enum ShopKeeperState
{
    Query,
    Fetching,
    Looking,
    Returning,
    Selling,
}

public enum BehaviorState
{
    Arrival,
    GoSHop,
    Order,
    Exit
}
