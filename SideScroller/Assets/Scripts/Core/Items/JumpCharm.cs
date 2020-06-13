using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCharm : InventoryItem
{
    private PlayerController controller;
    public override bool IsActive { get; set; }

    internal override Guid InventoryItemId => Guid.NewGuid();

    public override void ActivateEffect()
    {
        IsActive = true;
        controller.JumpForce += 1;
    }

    public override void RegisterServices(DependencyRepository repo)
    {
        controller = repo.ObjectDependencies[RegisteredServiceIds.PlayerController].GetComponent<PlayerController>();
    }

    public override void RemoveEffect()
    {
        IsActive = false;
        controller.JumpForce -= 1;
    }
}
