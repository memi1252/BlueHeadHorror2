using System;
using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;

public class villgeOut : MonoBehaviour
{
   public GameObject on;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         if (QuestManager.Instance.quests[4].isComplete)
         {
            QuestManager.Instance.CompleteQuest();
            Show();
            on.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
         }
      }
   }
   
   public void Show()
   {
      List<string> keys = new List<string>()
      {
         "player7-1",
         "player7-2",
      };
      DialogManager.Instance.onDialogStart += OnStart;
      DialogManager.Instance.onDialogComplete += OnEnd;
      DialogManager.Instance.Show(keys);
   }

   public void OnStart()
   {
      GameManager.Instance.playerMove = false;
   }

   public void OnEnd()
   {
      GameManager.Instance.playerMove = true;
   }
}
