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
        dataList.Add(new DialogData("플레이어: 아니 너는,,,"));
        dataList.Add(new DialogData("플레이어: 옛날에 꿈에서 봤던 그 괴물!!!"));
        dataList.Add(new DialogData("플레이어: 분명 꿈이였는데"));
        dataList.Add(new DialogData("파란머리: 하하 그게 꿈인줄 알았나"));
        dataList.Add(new DialogData("파란머리: 그때는 너에 대해 조사하기 위해서 꿈속으로 들어갔었지"));
        dataList.Add(new DialogData("플레이어: 뭐라고?"));
        dataList.Add(new DialogData("파란머리: 저번에는 조사를 위해 혼자 갔었지만 이번엔 친구들을 데리고 왔지"));
        dataList.Add(new DialogData("파란머리: 넌 이제 곧 몸이 이 작은파란머리 처럼 작아질 것이다"));
        dataList.Add(new DialogData("파란머리: 내 친구들을 피해 잘 살아보도록 그럼 이만 ^^"));
        dataList.Add(new DialogData("플레이어: 안돼!!!"));
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
