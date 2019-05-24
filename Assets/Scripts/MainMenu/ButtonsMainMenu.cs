using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    public void ButtonClickedAndLoadScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    public IEnumerator LoadScene(string sceneName)
    {
        foreach (GameObject button in menuButtonList)
        {
            button.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        buttonAnimator.SetTrigger("selected");
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(AnimationManager.instance.Fade(sceneName));
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
