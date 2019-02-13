using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class LetterScript : MonoBehaviour {

    private Animator anim;
    private Button butt;
    private GameObject handButton;
    private GameObject learningText;
    public VideoClip videoClip;

    private VideoManager videoManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        butt = GetComponent<Button>();
        learningText = GameObject.Find("LearningTextBox") as GameObject;
        handButton = GameObject.Find("HandButton") as GameObject;
    }

    void Start()
    {
        butt.interactable = false;
        StartCoroutine(waitForAnimation());
        videoManager = VideoManager.instance;
    }

    private IEnumerator waitForAnimation()
    {
        yield return new WaitForSeconds(2);
        butt.interactable = true;
    }

    public void ClickOnLetterWrapper()
    {
        StartCoroutine(ClickOnLetter());
    }

    private IEnumerator ClickOnLetter()
    {
        anim.Play("LetterFailing");
        anim = learningText.GetComponent<Animator>();
        anim.Play("TextBoxAnimationBeta");
        anim = GameObject.Find("VideoBox").GetComponent<Animator>();
        anim.Play("VideoBoxAnimation");
        yield return new WaitForSeconds(1);
        RawImage image = GameObject.Find("Tela").GetComponent<RawImage>();
        videoManager.PlayVideo(image, videoClip);
    }
}