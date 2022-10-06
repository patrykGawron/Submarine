using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class HighScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] scoreTexts;
    [SerializeField] private TextMeshProUGUI[] nameTexts;
    void Start()
    {
        GameManager.Instance.Won.Where(won => won).Subscribe(_ =>
        {
            float score = GameManager.Instance.TimeProperty.Value;
            if (GameManager.Instance.Scores.Count < 3)
            {
                GameManager.Instance.Scores.Add(new HighScore(GameManager.Instance.playerName, score));
                GameManager.Instance.Scores.Sort((first, second) => { return (int)(second.Score - first.Score); });
            }
            else
            {
                foreach (var scr in GameManager.Instance.Scores)
                {
                    if (score > scr.Score)
                    {
                        GameManager.Instance.Scores.Insert(
                            GameManager.Instance.Scores.IndexOf(scr),
                            new HighScore(GameManager.Instance.playerName, score));
                        break;
                    }
                }
            }


            for (int i = 0; i < scoreTexts.Length; ++i)
            {
                if (i < GameManager.Instance.Scores.Count)
                {
                    scoreTexts[i].text = GameManager.Instance.Scores[i].Score.ToString();
                    nameTexts[i].text = GameManager.Instance.Scores[i].Name;
                }
                else
                {
                    scoreTexts[i].text = "-";
                    nameTexts[i].text = "-";
                }
            }

            GameManager.Instance.SaveScores();

        }).AddTo(this);

    }
}
