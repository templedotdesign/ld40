using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Clock clock;
    public Loss loss;

    void Start()
    {
        clock.ResetClock(); 
        loss.Reset();
    }

    void Update() 
    {
        clock.UpdateClock(Time.deltaTime);
    }
}
