using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeSystemConfig", menuName = "Configs/TimeSystemConfig", order = 2)]
public class TimeSystemConfig : ScriptableObject
{
    [Header("Day-Cycle")]
    public int HoursPerDay = 24;

    public int MinutesPerHour = 60;

    public float SecondsPerMinute = 1f;
}
