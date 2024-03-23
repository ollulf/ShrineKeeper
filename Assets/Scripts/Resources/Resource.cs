using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Resource
{
    private enum ResourceType { Undefined, Gold }

    [SerializeField] private ResourceType scoreType = ResourceType.Undefined;


    [SerializeField] private string name = "";
    public string Name { get => name; }


    [SerializeField] private int amount = 0;
    public int Amount { get => amount; set => this.amount = value; }
}
