using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ReactiveProperty<float> TimeProperty { get; private set;  } = new ReactiveProperty<float>(120);
    public ReactiveProperty<bool> Won { get; private set; } = new ReactiveProperty<bool>(false);


    [SerializeField] private GameObject HUD, Menu, WinScreen, LoseScreen;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
        Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            TimeProperty.Value--;
            if (TimeProperty.Value == 0)
            {
                LoseScreen.SetActive(true);
                HUD.SetActive(false);
            }
        }).AddTo(this);

        Won.Subscribe(won =>
        {
            if (won)
            {
                HUD.SetActive(false);
                WinScreen.SetActive(true);
            }
        }).AddTo(this);

    }

    void Update()
    {
        
    }
}
