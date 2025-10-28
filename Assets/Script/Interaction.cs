using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float range;

    private void Update()
    {
        // 화면 중앙 좌표 계산
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        
        
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red);
        if (Physics.Raycast(ray, out hit, range, LayerMask.GetMask("Item")))
        {
            Item item = hit.collider.GetComponent<Item>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (item.interactionFeedback != null)
                {
                    item.interactionFeedback.PlayFeedbacks();
                }

                if (item.onItemUse != null)
                {
                    item.onItemUse.Invoke();
                }
            }
            string text = item.ItemName + " " + item.ItemAction;
            
            UIManager.Instance.interactionUI.Show(text);
        }
        else
        {
            UIManager.Instance.interactionUI.Hide();
        }
    }
}
