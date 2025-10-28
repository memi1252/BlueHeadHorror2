using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WayPointUI : MonoBehaviour
{
    public Image img;
    public Transform target;
    public TextMeshProUGUI text;
    public float distance;

    public bool isActive = false;
    public Vector3 offset;

    private void Update()
    {
        img.gameObject.SetActive(isActive);
        if(target == null) return;
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;
        
        if(Camera.main == null) return;
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

        if (Vector3.Dot((target.position - transform.position), Vector3.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }
        
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        img.transform.position = pos;
        distance = Vector3.Distance(GameManager.Instance.playerTransform.position, target.position);
        text.text = $"{(int)distance}m";

        if (distance < 5f)
        {
            img.transform.localScale = Vector3.one * 0.5f;
            img.color = new Color(1f, 1f, 1f, 0.5f);
            
        }
        else
        {
            img.transform.localScale = Vector3.one;
            img.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
