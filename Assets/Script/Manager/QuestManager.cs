using System;
using System.Collections;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct Quest
{
    public string questName;
    public bool isComplete;
}



public class QuestManager : MonoSingleton<QuestManager>
{
    public Quest[] quests;
    public int currentQuest = 0;
    public TextMeshProUGUI questText;
    private bool isComplete = false;

    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (!isComplete)
        {
            if (quests.Length != currentQuest + 1)
            {
                questText.text = $"퀘스트: {quests[currentQuest].questName}";
                questText.color = Color.white;
                if (quests[currentQuest].isComplete)
                {
                    isComplete = true;
                    StartCoroutine(QusetComplete());
                }
            }
            else
            {
                questText.text = $"더이상 퀘스트가 존재하지 않음";
                questText.color = Color.red;
                if (quests.Length < currentQuest + 1)
                {
                    currentQuest = quests.Length - 1;
                }
            }
            
        }
        
        
    }
    
    IEnumerator QusetComplete()
    {
        questText.text = $"퀘스트: {quests[currentQuest].questName} 완료";
        questText.color = Color.green;
        yield return new WaitForSeconds(2f);
        isComplete = false;
        currentQuest++;
    }

    public void CompleteQuest()
    {
        quests[currentQuest].isComplete = true;
    }
}
