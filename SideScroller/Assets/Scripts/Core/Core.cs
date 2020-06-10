using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Dictionary<Guid, MonoBehaviour> RegisteredDependencies = new Dictionary<Guid, MonoBehaviour>();
}

public static class ServiceGuids
{
    public static readonly Guid Player = Guid.Parse("044C559A-E5B9-402E-B54E-9BD8AFB55CAF");
}
