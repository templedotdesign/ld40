using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Temple/MenuEvents")]
public class MenuEvents : ScriptableObject {
    public void LoadScene(int buildIndex) {
        SceneManager.LoadScene(buildIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
