using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampButton : MonoBehaviour
{
    private Button lampButton;
    
    private void Awake()
    {
        lampButton = GetComponent<Button>();
        lampButton.interactable = false;
    }
}
