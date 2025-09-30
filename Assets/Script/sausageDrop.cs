using System;
using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;

public class sausageDrop : MonoBehaviour
{
    public GameObject miniBlueHeadShow;
    public MMF_Player sausageDropFeedback;

    private bool started = false;

    private void Update()
    {
        if (!started)
        {
            if (sausageDropFeedback.IsPlaying)
            {
                started = true;
                StartCoroutine(GameStart());
            }
        }
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);
        miniBlueHeadShow.SetActive(true);
        GameManager.Instance.playerCamera = false;
        GameManager.Instance.playerMove = false;
        UIManager.Instance.interactionUI.Hide();
        QuestManager.Instance.CompleteQuest();
        Destroy(gameObject);
    }
}


