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
            anim.SetTrigger("Close");
            isOpen = false;
            ItemAction = openkey;
        }
        else
        {
            anim.SetTrigger("Open");
            isOpen = true;
            ItemAction = closekey;
        }
    }

    private void OnDestroy()
    {
        onItemUse -= OnItemUse;
    }
}
