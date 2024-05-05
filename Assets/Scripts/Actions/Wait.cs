using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Action
{
    [SerializeField] private float waitTime = 0;

    public Wait(float time)
    {
        waitTime = time;
    }

    protected override IEnumerator ActionCoroutine()
    {
        float elapsedTime = 0;

        // waits until idle time done
        while (waitTime > elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public override IEnumerator StartActionRoutine(NPC npc)
    {
        yield return base.StartActionRoutine(npc);
    }

}
