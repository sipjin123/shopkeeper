using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScrapperManager : MonoBehaviour
{
    private DateTime _huntTime;
    private DateTime _returnTime;
    float _gameTime = 0;

    private bool _startHunt;
    [SerializeField]   private Transform _exitLocation, _startLocation;

    [SerializeField] private List<NavMeshAgent> _scrapperList;

    [SerializeField] private float _lootTime = 10;
    
    void FixedUpdate()
    {
        if (_startHunt)
        {
            
            _gameTime += Time.deltaTime;
            if (_gameTime >= _lootTime)
            {
                ReturnFromHunt();
                StartCoroutine(DelayScrapperLogic(false));
            }
        }
    }

    private void ReturnFromHunt()
    {
        foreach (var scapper in _scrapperList)
        {
            scapper.SetDestination(_startLocation.position);
        }

        StartCoroutine(DelayScrapperLogic(false));
    }

    public void StartHunting()
    {
        foreach (var scapper in _scrapperList)
        {
            scapper.SetDestination(_exitLocation.position);
        }

        StartCoroutine(DelayScrapperLogic(true));
    }

    IEnumerator DelayScrapperLogic(bool val)
    {
        yield return  new WaitForSeconds(2);
        _startHunt = val;
        _gameTime = 0;
    }
}
