using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCharm : InventoryItem, IItemEffect
{
    private PlayerController controller;
    public bool IsActive { get; set; }

    public void ActivateEffect()
    {
        IsActive = true;
        controller.JumpForce += 1;
    }

    public void RegisterServices(Dictionary<Guid, MonoBehaviour> registeredServices)
    {
        controller = registeredServices[ServiceGuids.Player].GetComponent<PlayerController>();
    }

    public void RemoveEffect()
    {
        IsActive = false;
        controller.JumpForce -= 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
