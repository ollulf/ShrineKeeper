using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    protected abstract IEnumerator ActionCoroutine();
    public virtual IEnumerator StartActionRoutine(NPC npc)
    {
        yield return npc.StartCoroutine(ActionCoroutine());
    }
}
