using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ExpCharm : InventoryItem
{
    private PlayerProgression progression;
    private float AdditiveXp = .25f;
    public override bool IsActive { get ; set ; }

    internal override Guid InventoryItemId => Guid.NewGuid();

    public override void ActivateEffect()
    {
        IsActive = true;
        progression.AddXpMultiplier(AdditiveXp);
    }

    public override void RemoveEffect()
    {
        IsActive = false;
        progression.AddXpMultiplier(-AdditiveXp);
    }

    public override void RegisterServices(DependencyRepository repo)
    {
        progression = repo.ObjectDependencies[RegisteredServiceIds.PlayerProgression].GetComponent<PlayerProgression>();
    }
}
