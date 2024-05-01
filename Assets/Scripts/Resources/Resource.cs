using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Resource
{
    public enum Type { Undefined, Gold, Faith}

    [SerializeField] public Type type = Type.Undefined;


    [SerializeField] private int amount = 0;
    public int Amount { get => amount; set => this.amount = value; }
}
