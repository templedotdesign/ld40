using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Clock clock;
    public Loss loss;

    bool gameOver = false;

    void Awake()
    {
        clock.ResetClock(); 
        loss.Reset();
    }

    void Update() 
    {
        if(loss.total >= 50) 
        {
            gameOver = true;    
        }

        if (!gameOver)
        {
            clock.UpdateClock(Time.deltaTime);
        }
    }
}
