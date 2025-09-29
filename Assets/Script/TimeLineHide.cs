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
    }

    void OnTimelineStopped(PlayableDirector director)
    {
        GameManager.Instance.playerCamera = playerCamera;
        GameManager.Instance.playerMove = playerMove;
        if(onTimelineEnd.GetPersistentEventCount() > 0)
        {
            Debug.Log(onTimelineEnd.GetPersistentEventCount());
            onTimelineEnd.Invoke();
        }
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
