using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



[CustomEditor(typeof(PlayerInventory))]
public class PlayerInventoryTool : Editor
{
    bool showRAw = false;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        PlayerInventory myScript = (PlayerInventory)target;

        if (GUILayout.Button("Force INITIALIZE  "))
        {
       //     myScript.RawItems = new Dictionary<LootItem, int>();

        }

        if (GUILayout.Button("Add Raw"))
        {
       //     myScript.RawItems.Add(myScript.ItemToAdd, myScript.AmountToAdd);
        }

        if (GUILayout.Button("ShowRawItems"))
        {
            showRAw = true;
        }

        if (showRAw)
        {
           // foreach (var aw in myScript.RawItems)
            {
               // GUILayout.Box(aw.Key + "  -  " + aw.Value);
            }
        }
    }
}