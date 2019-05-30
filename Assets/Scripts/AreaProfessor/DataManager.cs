using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Classe responsável por controlar as informações que serão salvas
/// </summary>
public class DataManager : MonoBehaviour
{
    public StatisticsData sumaryData = new StatisticsData();
    private string sumaryPath;
    private string sumaryHeader = "Nome,Ano,Pontuacao\n";

    private string playerPath;
    private string playerHeader;

    private Player playerTemp;

    public static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }

        sumaryPath = Application.persistentDataPath + "/ResumoJogadores.csv";

    }

    /// <summary>
    /// Função que cria um resumo dos jogadoresm em um arquivo
    /// </summary>
    public void PlayersSummary()
    {
        FileManager.instance.SetHeader(sumaryHeader);
        FileManager.instance.SetPath(sumaryPath);
        FileManager.instance.OverwriteFile();
        FileManager.instance.AddHeaderToFile();

        for (int i = 0; i < SaveManager.slotsListSize; i++)
        {
            if (!SaveManager.instance.list.slotsList.Contains(i))
            {
                playerTemp = SaveManager.instance.LoadPlayer(i);

                sumaryData.SetValues(playerTemp);
                FileManager.instance.SetData(sumaryData.ToString());
                FileManager.instance.AddDataToFile();
            }
        }
    }
}
