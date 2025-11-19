using System.Collections;
using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class Way : MonoBehaviour
{
    public GameObject[] monsters;
    public GameObject Camera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (QuestManager.Instance.quests[4].isComplete)
            {
                QuestManager.Instance.quests[QuestManager.Instance.currentQuest].questName = "quest8";
                Show();
            }
        }
    }

    IEnumerator e()
    {
        foreach (GameObject monster in monsters)
        {
            monster.SetActive(true);
        }

        UIManager.Instance.wayPointUI.isActive = false;
        Camera.SetActive(true);
        yield return new WaitForSeconds(7);
        Camera.SetActive(false);
        GameManager.Instance.playerMove = true;
        UIManager.Instance.wayPointUI.isActive = true;
        GameManager.Instance.playerCamera = true;
        yield return null;
    }
   
    public void Show()
    {
        List<string> keys = new List<string>()
        {
            "player8-1",
        };
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(keys);
        StartCoroutine(e());
    }

    public void OnStart()
    {
        GameManager.Instance.playerMove = false;
        GameManager.Instance.playerCamera = false;
    }

    public void OnEnd()
    {
        
    }
}
