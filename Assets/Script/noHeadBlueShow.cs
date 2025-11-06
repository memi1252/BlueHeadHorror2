using UnityEngine;

public class noHeadBlueShow : MonoBehaviour
{
    public bool isShow = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isShow)
        {
            
            var angle= GameManager.Instance.playerTransform.eulerAngles;
            Debug.Log(angle);
            GameManager.Instance.playerMove = false;
            if (angle.y > 180 && angle.y < 247)
            {
                GameManager.Instance.playerTransform.eulerAngles = new Vector3(angle.x, 217, angle.z);
                GameManager.Instance.playerTransform.localPosition = new Vector3(-144.123306f,31.0871201f,71.4177704f);
                transform.GetChild(0).gameObject.SetActive(true);
                GameManager.Instance.playerCamera = false;
                isShow = false;
            }
        }
    }
}
