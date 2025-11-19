using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void GameStart()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        LoadingBar.LoadScene("Game");
    }

    public void GameQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
    }
}
