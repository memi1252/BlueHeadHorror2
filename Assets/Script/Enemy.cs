using System;
using System.Collections;
using StarterAssets;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform[] targets;
    public int currentIndex = 0;
    public float moveSpeed = 10;

    public Vector3 offset;
    public float radius;
    [Range(0, 360)]
    public float angle;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public bool playerDie = false;

    public GameObject playerDieEffect;

    private Rigidbody rb;
    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        agent.SetDestination(targets[currentIndex].position);
        agent.speed = moveSpeed;
        animator.SetBool("Move", true);
        StartCoroutine(FOVRountine());
    }

    private void Update()
    {
        if (targets != null)
        {
            GameObject playerObject = GameManager.Instance.playerObject;
            
            if(playerObject == null) return;
            if(playerDie) return;
            Transform playerTarget = playerObject.transform;

            float distance = Vector3.Distance(transform.position, playerTarget.position);
            if (distance <= 1f)
            {
                if (!playerDie)
                {
                    playerDie = true;
                    GameManager.Instance.playerMove = false;
                    GameManager.Instance.playerCamera = false;
                    foreach (var UI in UIManager.Instance.PlayerDieUIs)
                    {
                        UI.SetActive(false);
                    }

                    StartCoroutine(PlayerDie());
                }
                return;
            }
            
            if (canSeePlayer)
            {
                if (GameManager.Instance.playerTamge)
                {
                    agent.SetDestination(playerTarget.position);
                }
                else
                {
                    canSeePlayer = false;
                }
                
            }
            else
            {
                agent.SetDestination(targets[currentIndex].position);
                float dis = Vector3.Distance(transform.position, targets[currentIndex].position);
                if (dis <= 0.6f)
                {
                    currentIndex = (currentIndex +1) % targets.Length;
                }
            }
        }
    }

    IEnumerator PlayerDie()
    {
        playerDieEffect.SetActive(true);
        GetComponent<AudioSource>().Play();
        GameManager.Instance.playerTransform.position = FindAnyObjectByType<RedheadVillageGate>().pos.position;
        GameManager.Instance.playerTransform.rotation = FindAnyObjectByType<RedheadVillageGate>().pos.localRotation;
        FindAnyObjectByType<FirstPersonController>().CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(FindAnyObjectByType<RedheadVillageGate>().pos.localRotation.x, 0.0f, 0.0f);
        yield return new WaitForSeconds(5f);
        playerDieEffect.SetActive(false);
        playerDie = false;
        foreach (var UI in UIManager.Instance.PlayerDieUIs)
        {
            UI.SetActive(true);
        }
        GameManager.Instance.playerMove = true;
        GameManager.Instance.playerCamera = true;
    }
    
    private IEnumerator FOVRountine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeCheks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeCheks.Length != 0)
        {
            Transform target = rangeCheks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position +offset, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
