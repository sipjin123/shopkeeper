using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Text _statDebugTExt;

    [SerializeField] private Button _scrapLootButton;

    private void Awake()
    {
        Factory.Register<UIManager>(this);
    }

    void Start()
    {
        _scrapLootButton.onClick.AddListener(() =>
        {
            _gameManager.TriggerScavenge.Invoke();
            
        });

        UpdateStatDebug();
    }

    public void UpdateStatDebug()
    {
        List<LootItemInventory> lootInvent = Factory.Get<InventoryManager>().RawItemList();

        _statDebugTExt.text = "";
        foreach (var item in lootInvent)
        {
            _statDebugTExt.text += item.Item.name + "  :  " + item.Quantity +"\n";
        }
    }

    void Update()
    {
        
    }
}
