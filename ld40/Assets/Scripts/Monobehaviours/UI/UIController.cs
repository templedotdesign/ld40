using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour 
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lossText;
    public Clock clock;
    public Loss loss;

    void Update () 
    {
        timerText.text = "Time: " + clock.minutes.ToString() + ":" + clock.seconds.ToString("f2");
        lossText.text = "Boxes Lost: " + loss.total;
	}
}
