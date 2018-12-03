using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StyleChoicer : MonoBehaviour {
    Button librasEAudio;
    Button librasOuAudio;

    private void Awake()
    {
        librasEAudio = GameObject.Find("Alpha").GetComponent<Button>();
        librasOuAudio = GameObject.Find("Beta").GetComponent<Button>();
    }

    private void Start()
    {
        if (PlayerPrefs.GetString("Style", "Alpha").Equals("Alpha")) {
            librasEAudio.interactable = false;
        }
        else
        {
            librasOuAudio.interactable = false;
        }
    }

    public void ClickedAlpha()
    {
        librasEAudio.interactable = false;
        librasOuAudio.interactable = true;
        PlayerPrefs.SetString("Style", "Alpha");
        PlayerPrefs.Save();
        //gameManager.SetStyleManager("Alpha");
    }

    public void ClickedBeta()
    {
        librasEAudio.interactable = true;
        librasOuAudio.interactable = false;
        PlayerPrefs.SetString("Style", "Beta");
        PlayerPrefs.Save();
        //gameManager.SetStyleManager("Beta");
    }
}
