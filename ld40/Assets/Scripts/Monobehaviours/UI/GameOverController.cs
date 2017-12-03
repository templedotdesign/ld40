using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverController : MonoBehaviour {

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] InputField input;

    [SerializeField] Clock clock;
    [SerializeField] MenuEvents menu;
    [SerializeField] HighScores highScores;
    [SerializeField] ScoreData scoreData;

    string score;

	void Start () 
    {
        int remainder = (int)((clock.seconds % (int)clock.seconds) * 100);
        score = ((int)clock.totalTime * 10 + remainder).ToString();
        timeText.text = "Your Final Time Was " + clock.minutes.ToString() + ":" + clock.seconds.ToString("f2");
        scoreText.text = "You Score Is " + score;
	}

    public void Submit() {
        if(string.IsNullOrEmpty(input.text)) {
            menu.LoadScene(0);
        } else {
            string username = input.text;
            //string score = clock.minutes.ToString() + ":" + clock.seconds.ToString("f2");
            //string score = 50.ToString();
            highScores.AddNewHighScore(username, score);
            StartCoroutine(LoadMenu());
        }
    }

    IEnumerator LoadMenu() {
        while(scoreData.updatingScores) {
            yield return null;
        }

        menu.LoadScene(1);
    }

	
}
