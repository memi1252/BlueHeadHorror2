using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public bool playerMove = true;
    public bool playerCamera = true;
    public override void Awake()
    {
        base.Awake();
    }
}
