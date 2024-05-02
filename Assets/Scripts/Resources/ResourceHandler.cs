using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    public static ResourceHandler Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private Dictionary <Resource.Type, Resource> resources = new();

    internal static void AddResource(Resource.Type type, int v)
    {
        Instance.GetResource(type).Amount += v;

        Debug.Log(Instance.GetResource(type) + " was added " + v);

    }

    private Resource GetResource(Resource.Type type)
    {
        if (Instance.resources.TryGetValue(type, out Resource value))
        {
            return value;
        }

        Resource newResource = new();
        newResource.type = type;

        Instance.resources.Add(type, newResource);

        return newResource;
    }
}
