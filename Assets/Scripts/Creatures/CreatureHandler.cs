using Assets.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SingletonSettings(SingletonLifetime.Scene, _canBeGenerated: false, _eager: true)]
public class CreatureHandler : SingletonBehaviour<CreatureHandler>
{
    [SerializeField] private bool shouldSpawnCreatures;
    [SerializeField] private int creatureTargetCount;
    public bool ShouldSpawnCreatures => shouldSpawnCreatures;
    [SerializeField] List<Creature> activeCreatures = new();
    public int CurrentCreatureAmount => activeCreatures.Count;
    [SerializeField] float currentTimeOfDay;
    [SerializeField] int creatureTargetAmount;
    [SerializeField] AnimationCurve creatureTargetAmountOver24HourDayCurve;
    private void Update()
    {
        currentTimeOfDay = GameInstance.Current.TimeSystem.CurrentTime.TimeOfDayAs24Float;
        creatureTargetAmount = (int)creatureTargetAmountOver24HourDayCurve.Evaluate(currentTimeOfDay);

        shouldSpawnCreatures = CurrentCreatureAmount < creatureTargetAmount;

        if (CurrentCreatureAmount != creatureTargetAmount)
        {
            if (ShouldSpawnCreatures)
            {
                //SPAWN CREATURE
                activeCreatures.Add(CreatureSpawner.Instance.Spawn());
            }
            else
            {
                if (activeCreatures.Count > 0)
                {
                    activeCreatures[0].Leave();
                    activeCreatures.RemoveAt(0);
                }
            }
        }
    }
}
