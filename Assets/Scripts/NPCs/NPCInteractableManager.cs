using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[SingletonSettings(SingletonLifetime.Scene, _canBeGenerated: true, _eager: false)]
public class NPCInteractableManager : SingletonBehaviour<NPCInteractableManager>
{

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
