using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Temple/Clock")]
public class Clock : ScriptableObject {
    [HideInInspector]public float totalTime;

    public int minutes;
    public float seconds;

    public void UpdateClock(float time)
    {
        totalTime += time;
        minutes = (int)totalTime / 60;
        seconds = totalTime % 60;
    }

    public void ResetClock() 
    {
        totalTime = 0;
        minutes = 0;
        seconds = 0;
    }
}
