using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
    
    public void SaveQuizQuestionsToFile()
    {
        playerPath = Application.persistentDataPath + "/" + SaveManager.instance.player.GetNome() + ".csv";
        FileManager.instance.SetPath(playerPath);

        if (!FileManager.instance.VerifyFile())
        {
            FileManager.instance.CreateFile();
        }

        List<QuestionAndAnswer> qnA = SaveManager.instance.player.GetQnA();

        for (int i = 0; i < qnA.Count; i++)
        {
            FileManager.instance.SetData(qnA[i].ToString());
            FileManager.instance.AddDataToFile();
        }
    }

    public string PlayerInfoToString(int index)
    {
        playerTemp = SaveManager.instance.LoadPlayer(index);

        return playerTemp.GetNome() + "," + playerTemp.GetClassroom() + "," + playerTemp.GetQnA()[1].ToString();
    }
}
