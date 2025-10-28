using UnityEngine;

public class ReaHeadScrollUI : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameManager.Instance.playerMove = false;
        GameManager.Instance.playerCamera = false;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.Instance.playerMove = true;
        GameManager.Instance.playerCamera = true;
    }
}
