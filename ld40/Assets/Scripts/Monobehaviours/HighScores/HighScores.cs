using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighScores : MonoBehaviour
{
    [SerializeField] ScoreData scoreData;

    const string privateCode = "a973pJrixEqeponFB56a1wia6NgGJKX0WcyA-CAojAVw";
    const string publicCode = "5a232ba66b2b65c2d090abee";
    const string webURL = "http://dreamlo.com/lb/";

    //public HighScore[] highScoresList;
    //public Leaderboard leaderboard;

    //static HighScores instance;

    //void Awake() 
    //{
    //    instance = this;
    //    leaderboard = GetComponent<Leaderboard>();
    //}

    void Awake()
    {
        StartCoroutine(RefreshHighScores());  
    }

    public void AddNewHighScore(string username, string score) {
        StartCoroutine(UploadNewScore(username, score));
    }

    public void DownloadHighScores() {
        StartCoroutine(DownloadScores());
    }

    IEnumerator UploadNewScore(string username, string score) 
    {
        scoreData.updatingScores = true;
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        scoreData.updatingScores = false;
        if(string.IsNullOrEmpty(www.error)) 
        {
            Debug.Log("Upload Successful");
            DownloadHighScores();
        } 
        else 
        {
            Debug.Log("Error uploading: " + www.error);
        }
    }

    IEnumerator DownloadScores()
    {
        scoreData.updatingScores = true;
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        scoreData.updatingScores = false;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScores(www.text);
            //leaderboard.OnHighScoresDownloaded(highScoresList);
        } 
        else
        {
            Debug.Log("Error downloading: " + www.error);
        }
    }

    void FormatHighScores(string textStream) {
        scoreData.highScoresList.Clear();
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        //scoreData.highScoresList = new HighScore[entries.Length];
        for (int i = 0; i < entries.Length; i++) {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            scoreData.highScoresList.Add(new HighScore(entryInfo[0], entryInfo[1]));
        }
    }

    IEnumerator RefreshHighScores()
    {
        while (true)
        {
            DownloadHighScores();
            yield return new WaitForSeconds(30);
        }
    }
}


