using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score 
{
    private enum ScoreType {Undefined, Fame}

    [SerializeField] private ScoreType scoreType = ScoreType.Undefined;


    [SerializeField] private string name = "";
    public string Name { get => name; }


    [SerializeField] private int value = 0;
    public int Value { get => value; set => this.value = value; }
}
