using Assets.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TimePostProcessingModifier : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] AnimationCurve weightOverTimeOfDayIn24HourFloat;

    // Update is called once per frame
    void Update()
    {
        volume.weight = weightOverTimeOfDayIn24HourFloat.Evaluate(TimeHandler.Instance.CurrentTime.TimeOfDayAs24Float);
    }
}
