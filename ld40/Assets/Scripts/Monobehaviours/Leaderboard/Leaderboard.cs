using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    //public TextMeshProUGUI[] highScoreTextList;
    //HighScores highScores;
    //[SerializeField] ScoreData scoreData;

    void Start()
    {
        DisplayHighScores(scoreData.highScoresList);
    }

    //public void DisplayHighScores(List<HighScore> highScoreList)
    //{
    //    StartCoroutine(PrepareHighScores(highScoreList));
    //}

    //IEnumerator PrepareHighScores(List<HighScore> highScoreList)
    //{
    //    for (int i = 0; i < highScoreTextList.Length; i++)
    //    {
    //        highScoreTextList[i].text = (i + 1) + ". ";
    //        if (highScoreList.Count > i)
    //        {
    //            highScoreTextList[i].text += highScoreList[i].username + " - " + highScoreList[i].score;
    //        }
    //    }
    //    yield return new WaitForSeconds(1f);
    //}

    [SerializeField] TextMeshProUGUI highScoreLog;
    [SerializeField] ScoreData scoreData;

    void DisplayHighScores(List<HighScore> highScoreList) {
        highScoreLog.text = "";
        if(highScoreList.Count == 0) {
            highScoreLog.text = "No Scores Recorded";
        } else {
            for (int i = 0; i < highScoreList.Count; i++) {
                highScoreLog.text += (i + 1) + ". " + highScoreList[i].username + " - " + highScoreList[i].score + '\n';
            }
        }
    }

    public void Refresh() {
        DisplayHighScores(scoreData.highScoresList);
    }
}
