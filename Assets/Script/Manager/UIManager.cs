using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public InteractionUI interactionUI;
    public GameObject questUI;
    public GameObject crossHairUI;
    public WayPointUI wayPointUI;
    public ReaHeadScrollUI reaHeadScrollUI;
    public Image blackImage;
    
    public Action onFadeInCompleteCallback;


    public GameObject[] AllUI;
    public override void Awake()
    {
        base.Awake();
    }
    
    
    public void FadeInOut()
    {
        blackImage.color = new Color(0, 0, 0, 0f);
        blackImage.transform.parent.gameObject.SetActive(true);
        StartCoroutine(FadeInOutCoroutine());
    }

    IEnumerator FadeInOutCoroutine()
    {
        float alpha = blackImage.color.a;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackImage.color = new Color(0, 0, 0, 1f);
        onFadeInCompleteCallback?.Invoke();
        while (alpha > 1f)
        {
            alpha -= Time.deltaTime;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        blackImage.color = new Color(0, 0, 0, 0f);
        blackImage.transform.parent.gameObject.SetActive(false);
        onFadeInCompleteCallback = null;
    }

}
