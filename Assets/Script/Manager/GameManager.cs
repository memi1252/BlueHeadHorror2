using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public bool playerMove = true;
    public bool playerCamera = true;
    public bool playerTamge = true;

    public GameObject playerObject;
    public Transform playerTransform;
    public override void Awake()
    {
        base.Awake();
    }
}
