using System;
using System.Collections;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct Quest
{
    public string questName;
    public bool isComplete;
    public Transform questTarget;
    public int count;
    public int maxCount;
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
            if (quests.Length != currentQuest)
            {
                if (quests[currentQuest].maxCount == -1)
                {
                    questText.text = $"{LocalizationManager.Instance.GetText("quest")}: {LocalizationManager.Instance.GetText(quests[currentQuest].questName)}";
                }
                else
                {
                    if (quests[currentQuest].count >= quests[currentQuest].maxCount)
                    {
                        questText.text = $"{LocalizationManager.Instance.GetText("quest")}: {LocalizationManager.Instance.GetText(quests[currentQuest].questName)} ({quests[currentQuest].maxCount}/{quests[currentQuest].maxCount})";
                    }
                }
                
                questText.color = Color.white;
                UIManager.Instance.wayPointUI.target = quests[currentQuest].questTarget;
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
            }
            
        }
        
        
    }
    
    IEnumerator QusetComplete()
    {
        LocalizationManager.Instance.OnLanguageChanged += InstanceOnOnLanguageChanged;
        questText.text = $"{LocalizationManager.Instance.GetText("quest")}: {LocalizationManager.Instance.GetText(quests[currentQuest].questName)} {LocalizationManager.Instance.GetText("complete")}";
        questText.color = Color.green;
        yield return new WaitForSeconds(2f);
        LocalizationManager.Instance.OnLanguageChanged -= InstanceOnOnLanguageChanged;
        isComplete = false;
        currentQuest++;
    }

    private void InstanceOnOnLanguageChanged()
    {
        questText.text = $"{LocalizationManager.Instance.GetText("quest")}: {LocalizationManager.Instance.GetText(quests[currentQuest].questName)} {LocalizationManager.Instance.GetText("complete")}";
    }

    public void CompleteQuest()
    {
        if (quests[currentQuest].maxCount == -1)
        {
            quests[currentQuest].isComplete = true;
        }
        else
        {
            quests[currentQuest].count++;
            if (quests[currentQuest].count >= quests[currentQuest].maxCount)
            {
                quests[currentQuest].isComplete = true;
            }
        }
        
    }
}
