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
        List<string> keys = new List<string>()
        {
            "player4-1",
            "player4-2",
            "player4-3",
            "player4-4",
            "player4-5"
        };
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(keys);
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
        UIManager.Instance.wayPointUI.isActive = true;
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
        List<string> keys = new List<string>()
        {
            "system2"
        };
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(keys);
    }
}