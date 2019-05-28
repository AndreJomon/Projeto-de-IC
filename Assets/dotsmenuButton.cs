using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dotsmenuButton : MonoBehaviour
{
    private Animator animator;
    private Button home, voltar, glossario;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        home = GameObject.Find("home").GetComponent<Button>();
        voltar = GameObject.Find("voltar").GetComponent<Button>();
        glossario = GameObject.Find("glossario").GetComponent<Button>();
    }

    public void OpenMenu()
    {
        animator.SetBool("menuOn", !animator.GetBool("menuOn"));
    }

    public void EnableSubMenuButtons()
    {
        home.interactable = true;
        voltar.interactable = true;
        glossario.interactable = true;
    }

    public void DisableSubMenuButtons()
    {
        home.interactable = false;
        voltar.interactable = false;
        glossario.interactable = false;
    }
}
