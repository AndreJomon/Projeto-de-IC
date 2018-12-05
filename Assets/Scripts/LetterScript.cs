using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LetterScript : MonoBehaviour {

    private Animator anim;
    private Button butt;
    private GameObject handButton;
    private GameObject learningText;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        butt = GetComponent<Button>();
        learningText = GameObject.Find("LearningTextBox") as GameObject;
        handButton = GameObject.Find("HandButton") as GameObject;
    }

    void Start()
    {
        anim.Play("LetterComing");
        butt.interactable = false;
        StartCoroutine(waitForAnimation());
    }

    private IEnumerator waitForAnimation()
    {
        yield return new WaitForSeconds(2);
        butt.interactable = true;
    }

    public void ClickOnLetter()
    {
        anim.Play("LetterFailing");
        anim = learningText.GetComponent<Animator>();
        anim.Play("TextBoxAnimation");
        anim = handButton.GetComponent<Animator>();
        anim.Play("HandButtonAnimation");
        //this.gameObject.SetActive(false);
    }
}