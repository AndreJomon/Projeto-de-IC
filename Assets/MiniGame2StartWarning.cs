using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2StartWarning : MonoBehaviour
{
    private List<GameObject> potContent;

    private void Start()
    {
        potContent = Pot.GetPots();
    }

    private void ActiveWarning()
    {
        for (int i = 0; i < potContent.Count; i++)
        {
            if (potContent[i] != null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
