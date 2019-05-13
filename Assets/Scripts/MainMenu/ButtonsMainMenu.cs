using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsMainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator buttonAnimator;
    private GameObject[] menuButtonList;

    private void Awake()
    {
        buttonAnimator = GetComponent<Animator>();
        menuButtonList = GameObject.FindGameObjectsWithTag("ButtonMenu");
    }

    private void OnMouseEnter()
    {
        buttonAnimator.Play("button_mouse_hover_in");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GetComponent<UnityEngine.UI.Button>().interactable == true) {
            transform.SetAsLastSibling();
            buttonAnimator.SetBool("mouseon", true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonAnimator.SetBool("mouseon", false);
    }

    public void ButtonClicked()
    {
        foreach (GameObject button in menuButtonList)
        {
            button.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        buttonAnimator.SetTrigger("selected");
        //colocar função de loadscene with fade
    }
}
