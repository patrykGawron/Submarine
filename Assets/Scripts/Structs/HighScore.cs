using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HighScore
{
    public HighScore(string name, float score)
    {
        Name = name;
        Score = score;
    }

    public string Name { get; }
    public float Score { get; }
}
