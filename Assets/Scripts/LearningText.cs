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

    private bool stillTyping = false;
    private float letterPause;
    private int counter = 0;

    public bool GetStillTyping()
    {
        return stillTyping;
    }

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
        ButtonsDisable();
    }

    private void Start()
    {
        StartLetterByLetter(learningText[counter]);
        letterPause = PlayerPrefs.GetFloat("letterPause", 0.03f);
    }

    private void StartLetterByLetter(string message)
    {
        currentText.text = "";
        StartCoroutine(TypeText(message));
    }

    IEnumerator TypeText(string message)
    {
        if (PlayerPrefs.GetInt("instantText", 0) == 1)
        {
            currentText.text = message;
        }

        else
        {
            stillTyping = true;
            foreach (char letter in message.ToCharArray())
            {
                currentText.text += letter;
                yield return new WaitForSeconds(letterPause);
            }
            stillTyping = false;
        }
        ButtonsAbleChecker();
    }

    public void TypeEverything()
    {
        currentText.text = learningText[counter];
    }

    public void NextText()
    {
        ButtonsDisable();
        counter++;
        StartLetterByLetter(learningText[counter]);
    }

    public void BackText()
    {
        ButtonsDisable();
        counter--;
        StartLetterByLetter(learningText[counter]);
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
    }

    private void ButtonsDisable()
    {
        backButton.SetActive(false);
        nextButton.SetActive(false);
    }

}
