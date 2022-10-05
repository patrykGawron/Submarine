using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ReactiveProperty<float> timeProperty { get; private set;  } = new ReactiveProperty<float>(120);

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            timeProperty.Value--;
            if(timeProperty.Value == 0)
                Debug.Log("Game OVER");
        }).AddTo(this);

    }

    void Update()
    {
        
    }
}
