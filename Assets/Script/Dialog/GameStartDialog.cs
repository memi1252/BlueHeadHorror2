using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class GameStartDialog : MonoBehaviour
{
    public GameObject black;
    private void Start()
    {
        Show();
    }

    public void Show()
    {
        List<string> keys = new List<string>()
        {
            "gameStart1",
            "gameStart2",
            "gameStart3"
        };
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(keys);
    }

    public void OnStart()
    {
        GameManager.Instance.playerMove = false;
        GameManager.Instance.playerCamera = false;
    }

    public void OnEnd()
    {
        black.SetActive(false);
        UIManager.Instance.wayPointUI.isActive = true;
        GameManager.Instance.playerMove = true;
        GameManager.Instance.playerCamera = true;        
    }
}
