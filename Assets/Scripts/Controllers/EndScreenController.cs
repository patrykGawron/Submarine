using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    void Start()
    {
        restartButton.OnClickAsObservable().Subscribe(_ =>
        {
            GameManager.Instance.RestartGame();
        }).AddTo(this);
    }
}
