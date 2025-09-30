using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public InteractionUI interactionUI;
    public GameObject questUI;
    public GameObject crossHairUI;


    public GameObject[] AllUI;
    public override void Awake()
    {
        base.Awake();
    }
}
