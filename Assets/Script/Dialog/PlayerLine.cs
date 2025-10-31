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
        List<DialogData> dataList = new List<DialogData>();
        dataList.Add(new DialogData("플레이어: 아 내몸이 작아졌어,,,"));
        dataList.Add(new DialogData("플레이어: 그 파란머리 녀석 내몸을 이렇게 만들다니..."));
        dataList.Add(new DialogData("플레이어: 내가 어떻게든 봉인 시킨다!!!"));
        dataList.Add(new DialogData("플레이어: 여기 주변에 분명 도움이 될만한게 있을꺼야"));
        dataList.Add(new DialogData("플레이어: 일단 길을 따라 가보자"));
        DialogManager.Instance.Show(dataList);
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
        List<DialogData> dataList = new List<DialogData>();
        dataList.Add(new DialogData("플레이어: 이 종이는 뭐지?"));
        dataList.Add(new DialogData("플레이어: 이 빨간 머리는 뭐고"));
        dataList.Add(new DialogData("플레이어: 이거 혹시 파란 머리를 봉인 시킬수 있는 방법인가?"));
        dataList.Add(new DialogData("플레이어: 이 종이가 여기에 있다면 재료도 근처에있을꺼야"));
        dataList.Add(new DialogData("플레이어: 어서 찾아 보자!!"));
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
