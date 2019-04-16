using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    
    
    [SerializeField] private Button _scrapLootButton;
    void Start()
    {
        _scrapLootButton.onClick.AddListener(() =>
        {
            _gameManager.TriggerScavenge.Invoke();
            
        });
    }

    void Update()
    {
        
    }
}
