using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventsData { }

[Serializable]
public class LootItemEvent : UnityEvent<List<LootItem>>
{
}

[Serializable]
public class CustomerEvent : UnityEvent <AICustomer>
{

}