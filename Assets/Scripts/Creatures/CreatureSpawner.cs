using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : SingletonBehaviour<CreatureSpawner>
{
    [SerializeField] Creature creatureDummy;
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    public List<Transform> SpawnPoints => spawnPoints;

    protected override void Awake()
    {
        base.Awake();
        creatureDummy.gameObject.SetActive(false);
    }
    internal Creature Spawn()
    {
        var instance = Instantiate(creatureDummy);
        instance.gameObject.SetActive(true);
        instance.transform.position = spawnPoints.Random().position;
        return instance;
    }
}
