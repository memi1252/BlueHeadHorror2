using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class MiniBlueHeadRun : MonoBehaviour
{
    public void Show()
    {
        List<DialogData> dataList = new List<DialogData>();
        dataList.Add(new DialogData("플레이어: 어 뭐야?"));
        dataList.Add(new DialogData("플레이어: 고양이인가 그거 먹으면 안돼"));
        dataList.Add(new DialogData("플레이어: 안되겠다 따라 가야겠어"));
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
