using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Perguntas", menuName = "My Assets/Lista de Perguntas")]
public class Perguntas : ScriptableObject
{
    [SerializeField]
    private Pergunta[] quizQuestions;

    public Pergunta GetQuestion(int index)
    {
        return quizQuestions[index];
    }

    public int GetLenght()
    {
        return quizQuestions.Length;
    }
}
