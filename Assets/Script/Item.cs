using System;
using MoreMountains.Feedbacks;
using UnityEngine;

public enum ItemType
{
    Cook
}

public class Item : MonoBehaviour
{
    public ItemType itemType;
    public string ItemName;
    public string ItemAction;
    
    public Action onItemUse;

    public MMF_Player interactionFeedback;
}
