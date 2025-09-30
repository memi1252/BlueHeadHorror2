using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class GameStartDialog : MonoBehaviour
{
    private void Start()
    {
        Show();
    }

    public void Show()
    {
        List<DialogData> dataList = new List<DialogData>();
        dataList.Add(new DialogData("이상한 꿈을 꾸고 10년 뒤"));
        dataList.Add(new DialogData("혼자 힐링을 하러 꿈에서 나온 근처의 산에"));
        dataList.Add(new DialogData("캠핑을 오게 됬다"));
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(dataList);
    }

    public void OnStart()
    {
        GameManager.Instance.playerMove = false;
        GameManager.Instance.playerCamera = false;
    }

    public void OnEnd()
    {
        GameManager.Instance.playerMove = true;
        GameManager.Instance.playerCamera = true;        
    }
}
