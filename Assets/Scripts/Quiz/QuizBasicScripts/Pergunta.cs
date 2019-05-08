using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que armazena uma pergunta, as alterantivas de resposta e o índice da resposta correta
/// </summary>
[System.Serializable]
public class Pergunta
{
    [SerializeField]
    private DeafText question;
    [SerializeField]
    private DeafText[] alternative;
    [SerializeField]
    private int correctAnswer;

    /// <summary>
    /// Função que verifica se ovalor passado corresponde a resposta correta
    /// </summary>
    /// <param name="sel"></param>
    /// <returns></returns>
    public bool VerifyAnswer(int sel)
    {
        if (sel == correctAnswer)
        {
            return true;
        }
        else return false;
    }

    #region Set/Get das variáveis
    public DeafText GetQuestion()
    {
        return question;
    }

    /// <summary>
    /// Retorna a alternativa correspondente ao índice passado
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public DeafText GetAlternative(int index)
    {
        return alternative[index];
    }

    /// <summary>
    /// Retorna o número total de alternativas
    /// </summary>
    /// <returns></returns>
    public int GetNumberOfAlternatives()
    {
        return alternative.Length;
    }

    #endregion
}