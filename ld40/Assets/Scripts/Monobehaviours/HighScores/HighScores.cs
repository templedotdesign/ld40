using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighScores : MonoBehaviour
{
    const string privateCode = "a973pJrixEqeponFB56a1wia6NgGJKX0WcyA-CAojAVw";
    const string publicCode = "5a232ba66b2b65c2d090abee";
    const string webURL = "http://dreamlo.com/lb/";

    public HighScore[] highScoresList;
    public Leaderboard leaderboard;

    static HighScores instance;

    void Awake() 
    {
        instance = this;
        leaderboard = GetComponent<Leaderboard>();
    }

    public static void AddNewHighScore(string username, string score) {
        instance.StartCoroutine(instance.UploadNewScore(username, score));
    }

    public void DownloadHighScores() {
        StartCoroutine(DownloadScores());
    }

    IEnumerator UploadNewScore(string username, string score) 
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

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
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScores(www.text);
            leaderboard.OnHighScoresDownloaded(highScoresList);
        } 
        else
        {
            Debug.Log("Error downloading: " + www.error);
        }
    }

    void FormatHighScores(string textStream) {
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        highScoresList = new HighScore[entries.Length];
        for (int i = 0; i < entries.Length; i++) {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            highScoresList[i] = new HighScore(entryInfo[0], entryInfo[1]);
            Debug.Log(highScoresList[i].username + ": " + highScoresList[i].score);
        }
    }
}


