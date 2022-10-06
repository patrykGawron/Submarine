using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private Button startGameButton;

    void Start()
    {
        playerNameInputField.onEndEdit.AddListener(GetText);

        startGameButton.OnClickAsObservable().Subscribe(_ =>
        {
            GameManager.Instance.StartGame();
        }).AddTo(this);
    }

    void GetText(string name)
    {
        GameManager.Instance.playerName = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
