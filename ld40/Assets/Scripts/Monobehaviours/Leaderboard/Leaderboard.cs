using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour 
{
    public TextMeshProUGUI[] highScoreTextList;
    HighScores highScores;

    void Start()
    {
        highScores = GetComponent<HighScores>();

        StartCoroutine(RefreshHighScores());
    }

    public void OnHighScoresDownloaded(HighScore[] highScoreList) {
        for (int i = 0; i < highScoreTextList.Length; i++) {
            highScoreTextList[i].text = (i + 1) + ". ";
            if(highScoreList.Length > i) {
                highScoreTextList[i].text += highScoreList[i].username + " - " + highScoreList[i].score;
            }
        } 
    }

    IEnumerator RefreshHighScores() {
        while(true) {
            highScores.DownloadHighScores();
            yield return new WaitForSeconds(30);
        }
    }
}
