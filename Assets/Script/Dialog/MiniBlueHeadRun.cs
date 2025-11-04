using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class MiniBlueHeadRun : MonoBehaviour
{
    public void Show()
    {
        List<DialogData> dataList = new List<DialogData>();
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player1-1")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player1-2")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player1-3")));
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(dataList);
    }

    public void OnStart()
    {
        
    }

    public void OnEnd()
    {
        UIManager.Instance.wayPointUI.isActive = true;
    }
}
