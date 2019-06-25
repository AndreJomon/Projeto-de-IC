using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player
{
    [Tooltip("Slot de save")]
    [SerializeField]
    private int slot = -1; //Slots de save
    [Tooltip("Nome do aluno")]
    [SerializeField]
    private string nome = ""; //Nome do aluno
    [Tooltip("Classe escolar que o aluno pertence ")]
    [SerializeField]
    private string classroom = "";
    [Tooltip("Ranking do aluno")]
    [SerializeField]
    private int rankingPosition = -1;
    [Tooltip("Pontuação total do aluno")]
    [SerializeField]
    private int[] score = {0, 0, 0};
    private List<QuestionAndAnswer> questionAndAnswers = new List<QuestionAndAnswer>();
    [SerializeField]
    private bool[] beatedParts = new bool[4]; /*Cada espaço referente a uma parte, 0: Tutorial, 1: Arcade, 2: Balões e 3: Quiz*/

    #region Getter & Setters
    public void SetBeatPartTrue(int part)
    {
        beatedParts[part] = true;
    }

    public bool GetBeatPartStatus(int part)
    {
        return beatedParts[part];
    }

    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public void SetSlot(int slot)
    {
        this.slot = slot;
    }

    public void SetClassroom(string classroom)
    {
        this.classroom = classroom;
    }

    public int GetSlot()
    {
        return slot;
    }

    public string GetNome()
    {
        return nome;
    }

    public string GetClassroom()
    {
        return classroom;
    }

    public void SetRanking(int position)
    {
        rankingPosition = position;
    }

    public int GetRankingPosition()
    {
        return rankingPosition;
    }

    public void SetScore(int i, int score)
    {
        this.score[i] = score;
    }

    public int GetScore(int i)
    {
        return score[i];
    }

    public int[] GetScore()
    {
        return score;
    }

    public int GetTotalScore()
    {
        int soma = 0;
        foreach (int scoreValue in score)
        {
            soma += scoreValue;
        }
        return soma;
    }

    public void SetAll(int slot, string nome, string classroom, int[] score)
    {
        SetSlot(slot);
        SetNome(nome);
        SetClassroom(classroom);
        for (int i = 0; i<score.Length; i++)
        {
            this.score[i] = score[i];
        }
    }

    public void SetQnA(List<QuestionAndAnswer> list)
    {
        questionAndAnswers = list;
    }

    public List<QuestionAndAnswer> GetQnA()
    {
        return questionAndAnswers;
    }

    public override string ToString()
    {
        string playerAsString = DateTime.Now.ToString("dd/MM/yyyy - hh:mm") + " Jogador: " + nome + " Série: " + classroom + "\nPerguntas\n";

        for (int i = 0; i < questionAndAnswers.Count; i++)
        {
            playerAsString = "Dificuldade: " + questionAndAnswers[i].GetDificultyLevel().ToString() +
                " Pegunta selecionada: " + questionAndAnswers[i].GetQuestionNumber().ToString() + 
                " Resposta selecionada: " + questionAndAnswers[i].GetAnswerSelected().ToString() + "\n";
        }

        return playerAsString;
    }

    public string ShowAll()
    {
        return rankingPosition + " " + score + " " + nome + " " + classroom;
    }
    #endregion
}