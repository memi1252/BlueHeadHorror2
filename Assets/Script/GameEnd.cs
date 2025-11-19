using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public void gameEnd()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        LoadingBar.LoadScene("Loby");
    }
}
