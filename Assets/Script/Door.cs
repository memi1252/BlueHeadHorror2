using System;
using UnityEngine;

public class Door : Item
{
    private Animator anim;
    public bool isOpen;
    public string openkey;
    public string closekey;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        onItemUse += OnItemUse;
    }

    private void OnItemUse()
    {
        if (isOpen)
        {
            //에니메이션 재생
            isOpen = false;
            ItemAction = openkey;
        }
        else
        {
            isOpen = true;
            ItemAction = closekey;
        }
    }

    private void OnDestroy()
    {
        onItemUse -= OnItemUse;
    }
}
