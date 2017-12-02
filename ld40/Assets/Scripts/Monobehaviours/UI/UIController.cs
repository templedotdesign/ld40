using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI lossText;
    [SerializeField] Clock clock;
    [SerializeField] Loss loss;
    [SerializeField] GameData data;


    void Update () 
    {
        if(data.gameOver) 
        {
            return;
        }
            
        timerText.text = "Time: " + clock.minutes.ToString() + ":" + clock.seconds.ToString("f2");
        lossText.text = "Boxes Lost: " + loss.total;
	}
}
