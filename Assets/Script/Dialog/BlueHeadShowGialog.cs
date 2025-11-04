using System.Collections;
using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class BlueHeadShowGialog : MonoBehaviour
{
    public BlueHeadShow blueHeadShow;
    
    public void Show()
    {
        List<string> keys = new List<string>()
        {
            "player2-1",
            "player2-2",
            "player2-3",
            "player2-4",
            "player2-5",
            "player2-6",
            "player2-7",
            "player2-8",
            "player2-9",
            "player2-10"
        };
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(keys);
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
