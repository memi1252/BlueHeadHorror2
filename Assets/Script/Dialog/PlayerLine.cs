using System;
using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    public static PlayerLine Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Line1()
    {
        List<string> keys = new List<string>()
        {
            "player3-1",
            "player3-2",
            "player3-3",
            "player3-4",
            "player3-5"
        };
        DialogManager.Instance.Show(keys);
        //DialogManager.Instance.onDialogStart += Line1Start;
        DialogManager.Instance.onDialogComplete += Line1End;
    }
    private void Line1End()
    {
        FindAnyObjectByType<RedheadVillageGate>().col.isTrigger = true;
        GameManager.Instance.playerCamera = true;
        GameManager.Instance.playerMove = true;
        UIManager.Instance.wayPointUI.isActive = true;
        DialogManager.Instance.onDialogComplete -= Line1End;
    }
    
    
    public void Line2()
    {
        List<string> keys = new List<string>()
        {
            "player5-1",
            "player5-2",
            "player5-3",
            "player5-4",
            "player5-5"
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
