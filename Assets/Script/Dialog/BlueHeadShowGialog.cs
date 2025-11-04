using System.Collections;
using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class BlueHeadShowGialog : MonoBehaviour
{
    public BlueHeadShow blueHeadShow;
    
    public void Show()
    {
        List<DialogData> dataList = new List<DialogData>();
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-1")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-2")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-3")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-4")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-5")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-6")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-7")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-8")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-9")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player2-10")));
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(dataList);
    }

    private void OnStart()
    {
        GameManager.Instance.playerCamera = false;
        GameManager.Instance.playerMove = false;
    }

    private void OnEnd()
    {
        blueHeadShow.SmallPlayerStart();
        DialogManager.Instance.onDialogStart -= OnStart;
        DialogManager.Instance.onDialogComplete -= OnEnd;   
    }
    
    

}
