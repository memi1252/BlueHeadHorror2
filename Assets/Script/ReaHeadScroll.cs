using System;
using UnityEngine;

public class ReaHeadScroll : Item
{
    private void Start()
    {
        onItemUse += OnItemUse;
    }

    private void OnItemUse()
    {
        UIManager.Instance.reaHeadScrollUI.Show();
        QuestManager.Instance.CompleteQuest();
        UIManager.Instance.wayPointUI.isActive = false;
        gameObject.SetActive(false);
    }
}
