using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextSpeed : MonoBehaviour {

    Button slowText;
    Button mediumText;
    Button fastText;
    Button instantText;
    GameManager gameManager;

    private void Awake()
    {
        slowText = GameObject.Find("Lento").GetComponent<Button>();
        mediumText = GameObject.Find("Medio").GetComponent<Button>();
        fastText = GameObject.Find("Rapido").GetComponent<Button>();
        instantText = GameObject.Find("Instantaneo").GetComponent<Button>();
    }

    private void Start()
    {

        float currentLetterPause = PlayerPrefs.GetFloat("letterPause", 0.03f);

        if (PlayerPrefs.GetInt("instantText", 0) == 1)
        {
            instantText.interactable = false;
        }

        else if (currentLetterPause == 0.1f) {
            slowText.interactable = false;
        }
        else if (currentLetterPause == 0.03f)
        {
            mediumText.interactable = false;
        }
        else if (currentLetterPause == 0f)
        {
            fastText.interactable = false;
        }
        gameManager = GameManager.instance;
    }

    public void SlowClicked()
    {
        PlayerPrefs.SetFloat("letterPause", 0.1f);
        SetInstantTexToZero();
        slowText.interactable = false;
        mediumText.interactable = true;
        fastText.interactable = true;
        instantText.interactable = true;
        gameManager.SetInstantText(false);
    }

    public void MediumClicked()
    {
        PlayerPrefs.SetFloat("letterPause", 0.03f);
        SetInstantTexToZero();
        slowText.interactable = true;
        mediumText.interactable = false;
        fastText.interactable = true;
        instantText.interactable = true;
        gameManager.SetInstantText(false);
    }

    public void FastClicked()
    {
        PlayerPrefs.SetFloat("letterPause", 0f);
        SetInstantTexToZero();
        slowText.interactable = true;
        mediumText.interactable = true;
        fastText.interactable = false;
        instantText.interactable = true;
        gameManager.SetInstantText(false);
    }

    public void InstantClicked()
    {
        PlayerPrefs.SetInt("instantText", 1);
        slowText.interactable = true;
        mediumText.interactable = true;
        fastText.interactable = true;
        instantText.interactable = false;
        gameManager.SetInstantText(true);
    }

    private void SetInstantTexToZero()
    {
        PlayerPrefs.SetInt("instantText", 0);
    }
}
