using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe que organiza as informações para armazenar em um arquivo
/// </summary>
public class StatisticsData
{
    private string name;
    private string classroom;
    private int score;

    private string lineSeparator = "\n";
    private string fieldSeparator = ",";

    /// <summary>
    /// Armazena os valores do player que devem ser armazenados
    /// </summary>
    /// <param name="player"></param>
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
