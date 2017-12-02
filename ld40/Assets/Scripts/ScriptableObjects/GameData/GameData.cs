using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Temple/GameData")]
public class GameData : ScriptableObject {
    public bool gameOver;
    public Box selectedBox;


    public void Reset() {
        gameOver = false;
        selectedBox = null;
    }
}
