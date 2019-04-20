using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateScriptableObj {
    [MenuItem("Assets/Create/My ItemListData Object")]
    public static void CreateMyAsset()
    {
        ItemListData asset = ScriptableObject.CreateInstance<ItemListData>();

        AssetDatabase.CreateAsset(asset, "Assets/ItemListData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }


    [MenuItem("Assets/Create/My LootItem")]
    public static void CreatLootItem()
    {
        LootItem asset = ScriptableObject.CreateInstance<LootItem>();

        AssetDatabase.CreateAsset(asset, "Assets/LootItem.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/My PlayerInventory")]
    public static void CreatPlayerInventory()
    {
        PlayerInventory asset = ScriptableObject.CreateInstance<PlayerInventory>();

        AssetDatabase.CreateAsset(asset, "Assets/PlayerInventory.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

}