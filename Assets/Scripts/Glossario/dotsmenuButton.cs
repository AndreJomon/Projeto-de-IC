using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dotsmenuButton : MonoBehaviour
{
    private Animator animator;
    private Button home, voltar, glossario;
    private ColorBlock disabledButtonColorBlock, voltarOriginalColorBlock;

    private void Awake()
    {
        animator = GetComponent<Animator>();        
        home = GameObject.Find("home").GetComponent<Button>();
        voltar = GameObject.Find("voltar").GetComponent<Button>();
        glossario = GameObject.Find("glossario").GetComponent<Button>();
        disabledButtonColorBlock = voltar.colors;
        voltarOriginalColorBlock = voltar.colors;
        
    }

    public void OpenMenu()
    {
        animator.SetBool("menuOn", !animator.GetBool("menuOn"));
    }

    public void EnableSubMenuButtons()
    {
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {
            voltar.interactable = false;
            disabledButtonColorBlock.disabledColor = new Color(0.5f,0.5f,0.5f,0.5f);
            voltar.colors = disabledButtonColorBlock;
        }
        else
        {
            voltar.interactable = true;
        }
        home.interactable = true;        
        glossario.interactable = true;
    }

    public void DisableSubMenuButtons()
    {
        home.interactable = false;
        voltar.interactable = false;
        glossario.interactable = false;        
        voltar.colors = voltarOriginalColorBlock;
    }
}
