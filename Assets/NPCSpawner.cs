using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private GameObject NpcPrefab;

    [Button]
    void SpawnNPC()
    {
        var spawnTransforms = NPCInteractableManager.GetInteractables(typeof (NPCSpawnPoint));

        Instantiate(NpcPrefab, spawnTransforms [Random.Range(0, spawnTransforms.Count-1)].GetInteractionLocations()[0].position, Quaternion.identity);
    }

}
