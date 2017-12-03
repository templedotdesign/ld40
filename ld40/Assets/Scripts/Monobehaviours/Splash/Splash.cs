using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour {
    [SerializeField] MenuEvents menu;

    void Start()
    {
        StartCoroutine(SwitchScenes());
    }

    IEnumerator SwitchScenes() {
        yield return new WaitForSeconds(1.5f);
        menu.LoadScene(1);
    }
}
