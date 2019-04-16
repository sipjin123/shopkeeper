using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public UnityEvent TriggerScavenge = new UnityEvent();


    [SerializeField] private ScrapperManager _scrapperManager;
    void Start()
    {
        TriggerScavenge.AddListener(() => { _scrapperManager.StartHunting(); });
    }

    void Update()
    {
        
    }
}
