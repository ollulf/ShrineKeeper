using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCInteractableManager : MonoBehaviour
{

    public static NPCInteractableManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private Dictionary <Type, List<INPCInteractable>> interactables = new();

    public static void Register(INPCInteractable i)
    {
        GetInteractables(i.GetType()).Add(i);
    }

    public static INPCInteractable GetFirstInteractable(Type type)
    {
        var list = GetInteractables(type);

        if (list.Count != 0)
            return list[0];

        return null;
    }

    public static List <INPCInteractable> GetInteractables(Type type)
    {
        if (Instance.interactables.TryGetValue(type, out var value))
        {
            return value;
        }

        List <INPCInteractable> newInteractables = new();

        Instance.interactables.Add(type, newInteractables);

        return newInteractables;
    }

}
