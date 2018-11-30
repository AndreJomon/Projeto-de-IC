using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LearningText : MonoBehaviour {

    public static LearningText instance = null;
    public string[] learningText;
    
    Text currentText;
    GameObject nextButton;
    GameObject backButton;
    GameObject helpButton;
    GameManager gameManager;

    public float letterPause;
    private int counter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
        currentText = GameObject.Find("LearningText").GetComponent<UnityEngine.UI.Text>();
        nextButton = GameObject.Find("SkipButton");
        backButton = GameObject.Find("BackButton");
        helpButton = GameObject.Find("HandButton");
        counter = 0;
        ButtonsDisable();
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        StartLetterByLetter(learningText[counter]);
    }

    private void StartLetterByLetter(string message)
    {
        currentText.text = "";
        StartCoroutine(TypeText(message));
        ButtonsDisable();
    }
    
    IEnumerator TypeText(string message)
    {
        foreach (char letter in message.ToCharArray())
        {
            currentText.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        ButtonsAbleChecker();
    }

    public void NextText()
    {
        counter++;
        StartLetterByLetter(learningText[counter]);
        ButtonsDisable();
    }

    public void BackText()
    {
        counter--;
        StartLetterByLetter(learningText[counter]);
        ButtonsDisable();
    }

    public void ButtonsAbleChecker()
    {
        if (counter > 0)
        {
            backButton.SetActive(true);
        }

        if (learningText.Length-1 != counter)
        {
            nextButton.SetActive(true);
        }
        //helpButton.SetActive(true);
    }

    private void ButtonsDisable()
    {
        backButton.SetActive(false);
        nextButton.SetActive(false);
        //helpButton.SetActive(false);
    }
}
