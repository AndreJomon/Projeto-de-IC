using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextSpeed : MonoBehaviour {

    GameManager gameManager;
    Button slowText;
    Button mediumText;
    Button fastText;
    Button instantText;

    private void Awake()
    {
        slowText = GameObject.Find("Lento").GetComponent<Button>();
        mediumText = GameObject.Find("Medio").GetComponent<Button>();
        fastText = GameObject.Find("Rapido").GetComponent<Button>();
        instantText = GameObject.Find("Instantaneo").GetComponent<Button>();
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        mediumText.interactable = false;
    }

    public void SlowClicked()
    {
        gameManager.SetLetterPause(0.1f);
        slowText.interactable = false;
        mediumText.interactable = true;
        fastText.interactable = true;
        instantText.interactable = true;
        gameManager.SetInstantText(false);
    }

    public void MediumClicked()
    {
        gameManager.SetLetterPause(0.03f);
        slowText.interactable = true;
        mediumText.interactable = false;
        fastText.interactable = true;
        instantText.interactable = true;
        gameManager.SetInstantText(false);
    }

    public void FastClicked()
    {
        gameManager.SetLetterPause(0f);
        slowText.interactable = true;
        mediumText.interactable = true;
        fastText.interactable = false;
        instantText.interactable = true;
        gameManager.SetInstantText(false);
    }

    public void InstantClicked()
    {
        slowText.interactable = true;
        mediumText.interactable = true;
        fastText.interactable = true;
        instantText.interactable = false;
        gameManager.SetInstantText(true);
    }
}
