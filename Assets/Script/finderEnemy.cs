using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class finderEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    public GameObject playerDieEffect;
    public Transform origin;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        
        origin = transform;
    }

    private void Update()
    {
        GameObject playerObject = GameManager.Instance.playerObject;
            
        agent.SetDestination(target.position);
        if(playerObject == null) return;
        Transform playerTarget = playerObject.transform;

        float distance = Vector3.Distance(transform.position, playerTarget.position);
        if (distance <= 1f)
        {
            if (!GameManager.Instance.playerDie)
            {
                GameManager.Instance.playerDie = true;
                GameManager.Instance.playerMove = false;
                GameManager.Instance.playerCamera = false;
                foreach (var UI in UIManager.Instance.PlayerDieUIs)
                {
                    UI.SetActive(false);
                }
                GetComponent<AudioSource>().Play();

                StartCoroutine(PlayerDie());
            }
        }
    }
    
    IEnumerator PlayerDie()
    {
        playerDieEffect.SetActive(true);
        GetComponent<AudioSource>().Play();
        GameManager.Instance.playerTransform.position = FindAnyObjectByType<villgeOut>().transform.position;
        GameManager.Instance.playerTransform.rotation = FindAnyObjectByType<villgeOut>().transform.localRotation;
        FindAnyObjectByType<FirstPersonController>().CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(FindAnyObjectByType<villgeOut>().transform.localRotation.x, 0.0f, 0.0f);
        yield return new WaitForSeconds(5f);
        playerDieEffect.SetActive(false);
        foreach (var UI in UIManager.Instance.PlayerDieUIs)
        {
            UI.SetActive(true);
        }
        GameManager.Instance.playerDie = false;
        GameManager.Instance.playerMove = true;
        GameManager.Instance.playerCamera = true;
        transform.position = origin.position;
        transform.rotation = origin.rotation;
        gameObject.SetActive(false);
    }
}
