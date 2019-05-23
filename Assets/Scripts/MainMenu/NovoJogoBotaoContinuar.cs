using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovoJogoBotaoContinuar : MonoBehaviour
{
    private Button continuarButton;
    private Text nomeInputText;
    private Text serieInputText;

    private void Awake()
    {
        continuarButton = GameObject.Find("continuar").GetComponent<Button>();
        nomeInputText = GameObject.Find("InputFieldNome").GetComponentInChildren<Text>();
        serieInputText = GameObject.Find("InputFieldSerie").GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (nomeInputText.text == "" || serieInputText.text == "")
        {
            continuarButton.interactable = false;
        }
        else
        {
            continuarButton.interactable = true;
        }
    }

    public void InputConfirm()
    {
        SaveManager.instance.CreateNewPlayer();
        SaveManager.instance.player.SetNome(nomeInputText.GetComponent<Text>().text);
        SaveManager.instance.player.SetClassroom(serieInputText.GetComponent<Text>().text);
    }
}
