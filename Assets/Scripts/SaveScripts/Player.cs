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
    private int score = 0;

    #region Getter & Setters
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

    public void SetScore(int score)
    {
        this.score = score;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetAll(int slot, string nome, string classroom, int score)
    {
        SetSlot(slot);
        SetNome(nome);
        SetClassroom(classroom);
        SetScore(score);
    }
    #endregion
}