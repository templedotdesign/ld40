﻿using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Clock clock;
    [SerializeField] Loss loss;
    [SerializeField] GameData data;
    [SerializeField] GameObject boxPrefab;

    GameObject boxGO;
    BoxCollider2D boxCol;

    void Awake()
    {
        clock.ResetClock();
        loss.Reset();
        data.Reset();
    }

    void LateUpdate()
    {
        if(data.gameOver) 
        {
            if(data.selectedBox) {
                Destroy(data.selectedBox.gameObject);
            }
            return;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (loss.total >= 50)
        {
            data.gameOver = true;
        }

        clock.UpdateClock(Time.deltaTime);

        if(data.selectedBox) 
        {
            data.selectedBox.gameObject.transform.position = mousePos;
            data.selectedBox.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}
