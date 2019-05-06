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
    #endregion
}