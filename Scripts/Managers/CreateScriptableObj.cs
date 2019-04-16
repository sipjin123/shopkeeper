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
}