using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private void Start()
    {
        GameManager.Instance.TimeProperty.Subscribe(timeValue =>
        {
            timerText.text = timeValue.ToString();
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
