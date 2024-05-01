using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresHandler : MonoBehaviour
{
    public static ScoresHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] private Score[] scores;

    public Score[] getScores()
    {
        return null;
    }
}
