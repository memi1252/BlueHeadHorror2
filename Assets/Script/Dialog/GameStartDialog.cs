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
        List<DialogData> dataList = new List<DialogData>();
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("gameStart1")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("gameStart2")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("gameStart3")));
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(dataList);
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
