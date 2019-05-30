using UnityEngine;
using System.IO;

/// <summary>
/// Classe que gerencia a escrita de dados em um arquivo básico
/// </summary>
public class FileManager : MonoBehaviour
{
    /// Dados que serão salvos no arquivo ou que foram lidos do arquivo
    private string data;
    /// Cabeçalho do arquivo (opcional)
    private string header = "";
    /// Caminho do arquivo - deve conter o nome do arquivo e a extenção
    private string path = "";

    public static FileManager instance;

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
    }

    #region Get/Set
    public void SetData(string value)
    {
        data = value;
    }

    public string GetData()
    {
        return data;
    }

    public void SetHeader(string value)
    {
        header = value;
    }

    public string GetHeader()
    {
        return header;
    }

    public void SetPath(string value)
    {
        path = value;
    }

    public string GetPath()
    {
        return path;
    }

    #endregion
    /// <summary>
    /// Função que verifica se o arquivo em path existe
    /// </summary>
    /// <returns></returns>
    public bool VerifyFile()
    {
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Função que cria um arquivo em path caso não exista
    /// </summary>
    public void CreateFile()
    {
        if (!File.Exists(path))
        {
            StreamWriter sw = File.CreateText(path);
            sw.Close();
        }
        else
        {
            Debug.LogWarning("Arquivo já existente");
        }
    }

    /// <summary>
    /// Função que apaga o arquivo em path caso exista
    /// </summary>
    public void DeleteFile()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.LogWarning("Arquivo inexistente");
        }
    }

    /// <summary>
    /// Função que sobrescreve o arquivo em path
    /// </summary>
    public void OverwriteFile()
    {
        DeleteFile();
        CreateFile();
    }

    /// <summary>
    /// Função que adiciona o header ao arquivo em path caso exista
    /// </summary>
    public void AddHeaderToFile()
    {
        if (File.Exists(path))
        {
            File.AppendAllText(path, header);
        }
        else
        {
            Debug.LogWarning("Arquivo inexistente");
        }
    }

    /// <summary>
    /// Função que adiciona data ao arquivo em path caso exista. Adiciona ao final do arquivo
    /// </summary>
    public void AddDataToFile()
    {
        if (File.Exists(path))
        {
            File.AppendAllText(path, data);
        }
        else
        {
            Debug.LogWarning("Arquivo inexistente");
        }
    }

    /// <summary>
    /// Função que carrega os dados em data do arquivo em path caso exista
    /// </summary>
    public void LoadFile()
    {
        if (File.Exists(path))
        {
            data = File.ReadAllText(path);
        }
        else
        {
            data = "";
            Debug.LogWarning("Arquivo inexistente");
        }
    }
}
