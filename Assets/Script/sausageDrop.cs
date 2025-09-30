using System;
using UnityEngine;

public class sausageDrop : MonoBehaviour
{
    public GameObject miniBlueHeadShow;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            miniBlueHeadShow.SetActive(true);
            GameManager.Instance.playerCamera = false;
            GameManager.Instance.playerMove = false;
            UIManager.Instance.interactionUI.Hide();
            Destroy(gameObject);
        }
    }
}
