using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class BlueHeadShow : MonoBehaviour
{
    public SplineAnimate splineAnimate;
    public GameObject blueheadShowTimeLine;
    public GameObject blueHead;
    public Transform miniBlueHead;
    public float range;

    private void Start()
    {
        splineAnimate.Completed += OnSplineAnimationCompleted;
    }

    private void OnSplineAnimationCompleted()
    {
        GameManager.Instance.playerMove = false;
        GameManager.Instance.playerCamera = false;
        blueheadShowTimeLine.gameObject.SetActive(true);
        blueHead.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        splineAnimate.Completed -= OnSplineAnimationCompleted;
    }

    private void OnDisable()
    {
        splineAnimate.Completed -= OnSplineAnimationCompleted;
    }

    private void Update()
    {
        Collider[] miniBlueHeadNear= Physics.OverlapSphere(miniBlueHead.position, range);
        bool isPlayer = false;
        foreach (var nearObject in miniBlueHeadNear)
        {
            if (nearObject.CompareTag("Player"))
            {
                isPlayer = true;
            }
        }

        if (isPlayer)
        {
            splineAnimate.Play();
        }
        else
        {
            splineAnimate.Pause();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(miniBlueHead.position, range);
    }
    public GameObject player;
    public float scale = 0.3f;
    
    public void SmallPlayerStart()
    {
        StartCoroutine(SmallPlayer());
    }
    
    IEnumerator SmallPlayer()
    {
        Vector3 originalScale = player.transform.localScale;
        Vector3 targetScale = originalScale * scale;
        float duration = 2.0f; // 애니메이션 지속 시간
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            player.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        player.transform.localScale = targetScale;
        GameManager.Instance.playerMove = true;
        GameManager.Instance.playerCamera = true;        
    }
}
