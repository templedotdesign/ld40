using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Temple/Loss")]
public class Loss : ScriptableObject {
    public int total;

    public void Reset() {
        total = 0;
    }
}
