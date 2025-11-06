using System.Collections;
using System.Collections.Generic;
using Doublsb.Dialog;
using StarterAssets;
using UnityEngine;

public class BlueHeadShowGialog : MonoBehaviour
{
    public BlueHeadShow blueHeadShow;
    public Transform blueHeadTransform;
    
    public void Show()
    {
        List<string> keys = new List<string>()
        {
            "player2-1",
            "player2-2",
            "player2-3",
            "player2-4",
            "player2-5",
            "player2-6",
            "player2-7",
            "player2-8",
            "player2-9",
            "player2-10"
        };
        DialogManager.Instance.onDialogStart += OnStart;
        DialogManager.Instance.onDialogComplete += OnEnd;
        DialogManager.Instance.Show(keys);
    }

    private void OnStart()
    {
        GameManager.Instance.playerCamera = false;
        GameManager.Instance.playerMove = false;
    }

    private void OnEnd()
    {
        blueHeadShow.SmallPlayerStart();
        DialogManager.Instance.onDialogStart -= OnStart;
        DialogManager.Instance.onDialogComplete -= OnEnd;   
    }

    public void BlueHeadLook()
    {
        FindAnyObjectByType<FirstPersonController>().CinemachineCameraTarget.transform.LookAt(blueHeadTransform); 
        FindAnyObjectByType<FirstPersonController>().CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(FindAnyObjectByType<FirstPersonController>().CinemachineCameraTarget.transform.localRotation.x, 0.0f, 0.0f);
    }

}
