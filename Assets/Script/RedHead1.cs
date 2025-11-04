using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class RedHead1 : Item
{
    public void Start()
    {
        onItemUse += OnItemUse;
    }

    private void OnItemUse()
    {
        Line();
        QuestManager.Instance.CompleteQuest();
    }
    
    
    public void Line()
    {
        List<DialogData> dataList = new List<DialogData>();
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("system1-1")));
        DialogManager.Instance.Show(dataList);
        DialogManager.Instance.onDialogStart += Line2Start;
        DialogManager.Instance.onDialogComplete += Line2End;
    }

    private void Line2Start()
    {
        GameManager.Instance.playerCamera = false;
        GameManager.Instance.playerMove = false;
    }

    private void Line2End()
    {
        GameManager.Instance.playerCamera = true;
        GameManager.Instance.playerMove = true;
        DialogManager.Instance.onDialogStart -= Line2Start;
        DialogManager.Instance.onDialogComplete -= Line2End;
    }
}
