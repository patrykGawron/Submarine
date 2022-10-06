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

    public List<HighScore> Scores { get; set; } = new List<HighScore>();

    public string playerName;

    [SerializeField] private GameObject HUD, Menu, WinScreen, LoseScreen;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        Menu.SetActive(false);
        HUD.SetActive(true);

        TimeProperty.Value = 120;

        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive).completed += (op) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
        };
    }

    public void RestartGame()
    {
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);
        HUD.SetActive(true);

        SceneManager.UnloadSceneAsync("Game");
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive).completed += (op) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
        };

        Won.Value = false;
        TimeProperty.Value = 120;
    }

    void Start()
    {
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

        for (int i = 0; i < 3; ++i)
        {
            if (PlayerPrefs.HasKey("PlayerName" + i) && PlayerPrefs.HasKey("PlayerScore" + i))
            {
                Scores.Add(new HighScore(
                    PlayerPrefs.GetString("PlayerName" + i),
                    PlayerPrefs.GetFloat("PlayerScore" + i)
                    ));
            }
        }
    }

    public void SaveScores()
    {
        int maxIndex = Scores.Count > 3 ? 3 : Scores.Count;
        for (int i = 0; i < maxIndex; ++i)
        {
            PlayerPrefs.SetString("PlayerName" + i, Scores[i].Name);
            PlayerPrefs.SetFloat("PlayerScore" + i, Scores[i].Score);
        }
    }
}
