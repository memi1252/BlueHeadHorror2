using UnityEngine;

public class LanguageSwitcher : MonoBehaviour
{
    public void SetLanguageToKorean()
    {
        if (LocalizationManager.Instance != null)
        {
            LocalizationManager.Instance.CurrentLanguage = "ko";
            LocalizationManager.Instance.RefreshAllText();
        }
    }

    public void SetLanguageToEnglish()
    {
        if (LocalizationManager.Instance != null)
        {
            LocalizationManager.Instance.CurrentLanguage = "en";
            LocalizationManager.Instance.RefreshAllText();
        }
    }

    public void SetLanguageToJapanese()
    {
        if (LocalizationManager.Instance != null)
        {
            LocalizationManager.Instance.CurrentLanguage = "ja";
            LocalizationManager.Instance.RefreshAllText();
        }
    }
}