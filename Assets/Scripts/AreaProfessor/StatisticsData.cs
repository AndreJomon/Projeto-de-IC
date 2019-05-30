using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que armazena os dados que serão salvos em um arquivo. Deve possuir uma função ToString() que sobrescreve a original
/// </summary>
public class StatisticsData
{
    private string name;
    private string classroom;
    private int score;

    private string lineSeparator = "\n";
    private string fieldSeparator = ",";

    public void SetValues(Player player)
    {
        name = player.GetNome();
        classroom = player.GetClassroom();
        score = player.GetScore();
    }

    /// <summary>
    /// Coloca todos os dados em uma única string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return name + fieldSeparator + classroom + fieldSeparator + score + lineSeparator;
    }
}
