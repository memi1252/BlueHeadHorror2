using System;
using UnityEngine;

public class redHeadSpawn : MonoBehaviour
{
    public GameObject timeLine;
    public RedHeadOn[] redHeads;

    private void Update()
    {
        bool red = true;
        for (int i = 0; i < redHeads.Length; i++)
        {
            if (!redHeads[i].on)
            {
                red = false;
            }
        }

        if (red)
        {
            if (!timeLine.activeInHierarchy)
            {
                timeLine.SetActive(true);
                UIManager.Instance.wayPointUI.isActive = false;
                foreach (var redd in redHeads)
                {
                    redd.objec.SetActive(false);
                }

                foreach (var obj in FindAnyObjectByType<Way>().monsters)
                {
                    obj.SetActive(false);
                }
                
            }
                
        }
    }
}
