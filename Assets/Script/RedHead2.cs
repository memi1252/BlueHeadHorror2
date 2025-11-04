using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class RedHead2 : Item
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
        List<string> keys = new List<string>()
        {
            "system1-1"
        };
        DialogManager.Instance.Show(keys);
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
