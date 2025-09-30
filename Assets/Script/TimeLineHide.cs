using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class TimeLineHide : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public bool playerMove = true;
    public bool playerCamera = true;
    public UnityEvent onTimelineEnd;

    void Start()
    {
        if (timelineDirector != null)
        {
            timelineDirector.stopped += OnTimelineStopped;
        }
        UIManager.Instance.questUI.SetActive(false);
        UIManager.Instance.crossHairUI.SetActive(false);
    }

    void OnTimelineStopped(PlayableDirector director)
    {
        GameManager.Instance.playerCamera = playerCamera;
        GameManager.Instance.playerMove = playerMove;
        if(onTimelineEnd.GetPersistentEventCount() > 0)
        {
            onTimelineEnd.Invoke();
        }
        UIManager.Instance.questUI.SetActive(true);
        UIManager.Instance.crossHairUI.SetActive(true);
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (timelineDirector != null)
        {
            timelineDirector.stopped -= OnTimelineStopped;
        }
    }
}
