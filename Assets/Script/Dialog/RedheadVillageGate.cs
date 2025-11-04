using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class RedheadVillageGate : MonoBehaviour
{
    public Collider col;
    public Transform pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Show();
            col.enabled = false;
        }
    }

    public void Show()
    {
        List<DialogData> dataList = new List<DialogData>();
        
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player4-1")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player4-2")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player4-3")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player4-4")));
        dataList.Add(new DialogData(LocalizationManager.Instance.GetText("player4-5")));
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(dataList);
    }

    public void OnStart()
    {
        UIManager.Instance.wayPointUI.isActive = false;
        GameManager.Instance.playerMove = false;
        GameManager.Instance.playerCamera = false;
    }

    public void OnEnd()
    {
        QuestManager.Instance.CompleteQuest();
        GameManager.Instance.playerMove = true;
        GameManager.Instance.playerCamera = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            UIManager.Instance.onFadeInCompleteCallback += OnFadeInCompleteCallback;
            UIManager.Instance.FadeInOut();
        }
    }

    private void OnFadeInCompleteCallback()
    {
        GameManager.Instance.playerTransform.position = pos.position;
        Show2();
    }

    public void Show2()
    {
        List<DialogData> dataList = new List<DialogData>();
        dataList.Add(new DialogData("플레이어: 아직은 마을에 들어갈수 없어"));
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(dataList);
    }
}