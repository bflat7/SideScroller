using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ExpCharm : InventoryItem, IItemEffect
{
    private PlayerProgression progression;
    private float AdditiveXp = .01f;
    public bool IsActive { get ; set ; }

    public void ActivateEffect()
    {
        IsActive = true;
        progression.AddXpMultiplier(AdditiveXp);
    }

    public void RemoveEffect()
    {
        IsActive = false;
        progression.AddXpMultiplier(-AdditiveXp);
    }

    public void RegisterServices(Dictionary<Guid, MonoBehaviour> registeredServices)
    {
        progression = registeredServices[ServiceGuids.Player].GetComponent<PlayerProgression>();
    }
}

public interface IItemEffect
{
    bool IsActive { get; set; }
    void ActivateEffect();
    void RemoveEffect();
    void RegisterServices(Dictionary<Guid, MonoBehaviour> registeredServices);
}
