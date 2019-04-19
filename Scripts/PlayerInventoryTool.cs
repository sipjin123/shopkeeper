using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



[CustomEditor(typeof(PlayerInventory))]
public class PlayerInventoryTool : Editor
{
    bool showRAw = false;
    bool showEquipments = false;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        PlayerInventory myScript = (PlayerInventory)target;

        if (GUILayout.Button("Force INITIALIZE  "))
        {
            myScript.RawItems = new Dictionary<LootItem, int>();
            myScript.EquipmentItems = new Dictionary<CombinableItem, int>();
        }

        if (GUILayout.Button("Add Raw"))
        {
            myScript.RawItems.Add(myScript.ItemToAdd, myScript.AmountToAdd);
        }
        if (GUILayout.Button("Add Equipment"))
        {
            myScript.EquipmentItems.Add(myScript.CombinableItemToAdd, myScript.AmountToAdd);
        }

        if (GUILayout.Button("ShowRawItems"))
        {
            showRAw = true;
        }
        if (GUILayout.Button("ShowEquipment"))
        {
            showEquipments = true;
        }

        if (showRAw)
        {
            foreach (var aw in myScript.RawItems)
            {
                GUILayout.Box(aw.Key + "  -  " + aw.Value);
            }
        }
        if (showEquipments)
        {
            foreach (var aw in myScript.EquipmentItems)
            {
                GUILayout.Box(aw.Key + "  -  " + aw.Value);
            }
        }
    }
}