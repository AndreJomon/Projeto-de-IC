using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionAndAnswer
{
    [SerializeField] private int dificultyLevel = -1;
    [SerializeField] private int questionNumber = -1;
    [SerializeField] private int answerSelected = -1;
    [SerializeField] private bool isCorrect = false;

    public QuestionAndAnswer() { }

    public void SetDificultyLevel(int value)
    {
        dificultyLevel = value;
    }

    public void SetQuestionNumber(int value)
    {
        questionNumber = value;
    }

    public int GetQuestionNumber()
    {
        return questionNumber;
    }

    public void SetAnswerSelected(int value)
    {
        answerSelected = value;
    }

    public void SetIsCorrect(bool value)
    {
        isCorrect = value;
    }
}
