using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public bool playerMove = true;
    public bool playerCamera = true;
    public bool playerTamge = true;
    public bool playerDie = false;

    public GameObject playerObject;
    public Transform playerTransform;

    public GameObject ddd;
    public AudioSource pickupSound;
    public override void Awake()
    {
        base.Awake();
    }
}
