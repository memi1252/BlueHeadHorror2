using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public InteractionUI interactionUI;
    
    public override void Awake()
    {
        base.Awake();
    }
}
