using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que armazena as informações de uma pergunta realizada
/// </summary>
[System.Serializable]
public class QuestionAndAnswer
{
    [SerializeField] private int dificultyLevel = -1;
    [SerializeField] private int questionNumber = -1;
    [SerializeField] private int answerSelected = -1;
    [SerializeField] private bool isCorrect = false;

    /// <summary>
    /// Cosntrutor básico
    /// </summary>
    public QuestionAndAnswer() { }

    #region Set/Get das variáveis
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

    #endregion
}