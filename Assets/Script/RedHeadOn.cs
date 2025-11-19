using System;
using UnityEngine;

public class RedHeadOn : Item
{
    public GameObject objec;
    public GameObject Particle;
    public bool on;
    
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        onItemUse += OnItemUse;
    }

    private void OnItemUse()
    {
        objec.SetActive(true);
        on = true;
        audio.Play();
        Particle.SetActive(false);
        enabled = false;
    }
}
