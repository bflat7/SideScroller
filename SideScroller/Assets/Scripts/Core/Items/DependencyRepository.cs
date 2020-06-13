using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class DependencyRepository : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<GameObject> _InventoryItems;
    [SerializeField]
    private List<MonoBehaviour> _ObjectDependenciesList;
    
    public ReadOnlyDictionary<Guid, MonoBehaviour> ObjectDependencies { get; private set; }
    public ReadOnlyDictionary<Guid, InventoryItem> InventoryItems { get; private set; }

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        ObjectDependencies = new ReadOnlyDictionary<Guid, MonoBehaviour>(_ObjectDependenciesList.ToDictionary(i => (i as IRegisteredService).Id));
        InventoryItems = new ReadOnlyDictionary<Guid, InventoryItem>(_InventoryItems
            .Select(i => i.GetComponent<InventoryItem>())
            .ToDictionary(i => i.InventoryItemId));
    }
}
