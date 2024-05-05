using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSequence : Action
{
    private List<Action> actions = new();

    private int actionIndex = 0;


    protected override IEnumerator ActionCoroutine()
    {
        yield break;
    }

    public override IEnumerator StartActionRoutine(NPC npc)
    {
        yield return base.StartActionRoutine(npc);
    }
}
