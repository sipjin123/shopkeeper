using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombinable
{
    bool HasRequiredMaterials();
    List<LootItem> RequiredMaterials();

}