using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static StatisticsData statisticsData = new StatisticsData();
    private static string statisticsDataPath;
    private static string fileHeaderCSV = "Nome,Ano,Pontuacao\n";

    /// <summary>
    /// Verifica se o arquivo existe, se não existir cria
    /// </summary>
    public static void SelectProperFile()
    {
        statisticsDataPath = Application.persistentDataPath + "/PlayersInfo.csv";
        
        StreamWriter sw = File.CreateText(statisticsDataPath);
        sw.Close();
        File.AppendAllText(statisticsDataPath, fileHeaderCSV);
    }
    
    /// <summary>
    /// Adiciona os dados no arquivo
    /// </summary>
    public static void SaveStatistics()
    {
        if (File.Exists(statisticsDataPath))
        {
            File.AppendAllText(statisticsDataPath, statisticsData.ToString());
        }
        else
        {
            Debug.Log("Arquivo não encontrado");
        }
    }
}
