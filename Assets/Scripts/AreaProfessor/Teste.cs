﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    
    void Start()
    {
        if (!PlayerPrefs.HasKey("Senha"))
        {
            PlayerPrefs.SetString("Senha", "SenhaTeste01");
        }
    }

    public void CheckPassword()
    {
        string psw = GameObject.Find("Senha").GetComponent<UnityEngine.UI.InputField>().text;
        string sPsw = PlayerPrefs.GetString("Senha");
        if (string.Compare(psw, sPsw) == 0)
        {
            text.text = "Senha correta!";
        }
        else
        {
            text.text = "HaHaHa, vc não disse a palavra mágica!!!";
        }
    }

    public void ChangePassword(UnityEngine.UI.InputField newPswr)
    {
        string psw = newPswr.text;
        PlayerPrefs.SetString("Senha", psw);
        text.text = "Senha alterada com sucesso!";
    }
}
