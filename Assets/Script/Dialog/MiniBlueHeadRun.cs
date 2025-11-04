using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class MiniBlueHeadRun : MonoBehaviour
{
    public void Show()
    {
        List<string> keys = new List<string>()
        {
            "player1-1",
            "player1-2",
            "player1-3"
        };
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(keys);
    }

    public void OnStart()
    {
        
    }

    public void OnEnd()
    {
        UIManager.Instance.wayPointUI.isActive = true;
    }
}
