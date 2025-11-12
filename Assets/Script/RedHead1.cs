using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class RedHead1 : Item
{
    public bool isUsed = false;
    public GameObject timeLine;
    public void Start()
    {
        onItemUse += OnItemUse;
    }

    private void OnItemUse()
    {
        if (!isUsed)
        {
            GameManager.Instance.playerCamera = false;
            GameManager.Instance.playerMove = false;
            GameManager.Instance.playerTamge = false;
            timeLine.SetActive(true);
        }
        else
        {
            Line();
            QuestManager.Instance.CompleteQuest();
            Destroy(gameObject);
        }
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
    
    public void Line2()
    {
        List<string> keys = new List<string>()
        {
            "player6-1",
            "player6-2",
            "player6-3",
        };
        DialogManager.Instance.Show(keys);
        
        DialogManager.Instance.onDialogComplete += LineEnd;
    }

    private void LineEnd()
    {
        GameManager.Instance.playerCamera = true;
        GameManager.Instance.playerMove = true;
        GameManager.Instance.playerTamge = true;
        DialogManager.Instance.onDialogComplete -= LineEnd;
    }
}
