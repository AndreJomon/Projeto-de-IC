using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StyleChoicer : MonoBehaviour {
    Button librasEAudio;
    Button librasOuAudio;
    GameManager gameManager;

    private void Awake()
    {
        librasEAudio = GameObject.Find("Alpha").GetComponent<Button>();
        librasOuAudio = GameObject.Find("Beta").GetComponent<Button>();
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        librasEAudio.interactable = false;
    }

    public void ClickedAlpha()
    {
        librasEAudio.interactable = false;
        librasOuAudio.interactable = true;
        gameManager.SetStyleManager("Alpha");
    }

    public void ClickedBeta()
    {
        librasEAudio.interactable = true;
        librasOuAudio.interactable = false;
        gameManager.SetStyleManager("Beta");
    }
}
