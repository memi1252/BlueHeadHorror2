using System;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;


    public void Show(string text)
    {
        interactionUI.SetActive(true);
        interactionText.text = text +" (E)";
    }

    public void Hide()
    {
        interactionUI.SetActive(false);
    }
}
