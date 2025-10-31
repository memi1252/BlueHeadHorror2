using System;
using MoreMountains.Feedbacks;
using UnityEngine;


public class Item : MonoBehaviour
{
    public string ItemName;
    public string ItemAction;
    
    public Action onItemUse;

    public MMF_Player interactionFeedback;
}
