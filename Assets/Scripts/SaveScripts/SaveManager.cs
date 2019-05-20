﻿
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour {

    public static SaveManager instance;
    public static int slotsListSize = 50; //Quantidade de saves permitidos
    public string dataPath; //Caminho onde será salvo os arquivos
    public string slotsDataPath; //Caminho onde será salvo os arquivo concatenado com "listaDeSlots.json"
    public SlotsList list;
    public Player player;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        dataPath = Application.persistentDataPath;
        slotsDataPath = System.IO.Path.Combine(dataPath, "listaDeSlots.json");
        list = SlotsListManager.StartList(slotsDataPath);
    }

    /*
    public void Update()
    {
        //Debug.Log(player.slot);
    }
    */
    #region Create & Save & Load que será chamada

    public void CreateNewPlayer()///Modificar de acordo com sua primeira tela de save
    {
        Player newPlayer = new Player();
        player = newPlayer;
        SpecificFromGame();
        player.SetSlot(SlotsListManager.SlotGiver(list));
    }

    /// <summary>
    /// Detalhes do create new player especificas do jogos
    /// </summary>
    public void SpecificFromGame()
    {
    }

    public void Save()
    {
        string nomeDoJson = string.Concat(player.GetSlot(), ".json");
        string newDataPath = System.IO.Path.Combine(dataPath, nomeDoJson);
        SavePlayerData(newDataPath);
    }

    public void ResetSave()
    {
        DeletePlayer(player.GetSlot());
        player = new Player();
    }

    /// <summary>
    /// Recebe um inteiro informando o slot a ser carregado
    /// </summary>
    /// <param name="i"></param>
    public void Load(int i)
    {
        string tempPath = i.ToString();
        player = LoadPlayerData(tempPath + ".json");
    }

    /// <summary>
    /// Caso o Load seja chamado sem um inteiro, ele carrega o slot "0".
    /// </summary>
    public void Load()
    {
        Load(0);
    }

    public Player LoadPlayer(int i)
    {
        return LoadPlayerData(i.ToString() + ".json");
    }

    #endregion

    #region  Save & Load & Delete que fica por trás das cortinas

    /// <summary>
    /// Recebe o caminho e salva os dados do Player que está no SaveManager.player
    /// </summary>
    /// <param name="path"></param>
    private void SavePlayerData(string path)
    {
        if (player.GetSlot() == -1) //O número -1 é dado caso não haja mais espaços livres para salvar o jogo.
        {
            Debug.Log("Não foi possível criar um save");
        }

        else
        {
            SlotsListManager.RetiraKey(player.GetSlot());
            string json = JsonUtility.ToJson(player);

            StreamWriter sw = File.CreateText(path);
            sw.Close();

            File.WriteAllText(path, json);
        }
    }

    /// <summary>
    /// Recebe o nome do arquivo que deve ser carregado
    /// </summary>
    /// <param name="path"></param>
    private Player LoadPlayerData(string path)
    {
        // Completa o caminho com o nome do arquivo
        string newDataPath = Path.Combine(dataPath, path);
        // Verifica se o arquivo existe
        if (File.Exists(newDataPath))
        {
            // Se existe, carrega o arquivo no SaveManager
            string dataAsJson = File.ReadAllText(newDataPath);
            //player = JsonUtility.FromJson<Player>(dataAsJson);
            return JsonUtility.FromJson<Player>(dataAsJson);
        }
        // Se não existe, avisa
        else
        {
            Debug.LogError("Não foi possível carregar o save!");
            return null;
        }
    }

    
    /// Se quiser melhorar no futuro: Fazer esse código ser private, e chamá-lo de outro lugar    
    public void DeletePlayer(int slot)
    {
        string stringSlot = (slot.ToString() + ".json");

        System.IO.File.Delete(System.IO.Path.Combine(dataPath, stringSlot));
        //Debug.Log(SaveManager.selectedSlot);
        SlotsListManager.ReturnSlot(slot);

    }

    #endregion
}
