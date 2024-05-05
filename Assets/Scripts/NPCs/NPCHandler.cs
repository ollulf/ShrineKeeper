using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[SingletonSettings(SingletonLifetime.Scene, _canBeGenerated: true, _eager: false)]
public class NPCHandler : SingletonBehaviour<NPCHandler>
{
    [SerializeField] private bool shouldSpawnNPC;

    [SerializeField] private List<NPC> activeNPCs = new();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
