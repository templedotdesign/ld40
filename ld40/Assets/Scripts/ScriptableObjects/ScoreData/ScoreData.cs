using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Temple/ScoreData")]
public class ScoreData : ScriptableObject {
    public List<HighScore> highScoresList;
    public bool updatingScores;
}
