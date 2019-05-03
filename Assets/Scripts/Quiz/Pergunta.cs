using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pergunta
{
    [SerializeField]
    private DeafText question;
    [SerializeField]
    private DeafText[] alternative;
    [SerializeField]
    private int correctAnswer;

    public bool VerifyAnswer(int sel)
    {
        if (sel == correctAnswer)
        {
            return true;
        }
        else return false;
    }

    public DeafText GetQuestion()
    {
        return question;
    }

    public DeafText GetAlternative(int index)
    {
        return alternative[index];
    }
}
