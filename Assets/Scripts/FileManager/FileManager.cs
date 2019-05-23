using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    private string data;
    private string header = "";
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

    public void OverwriteFile()
    {
        DeleteFile();
        CreateFile();
    }

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

    public void LoadFile()
    {
        if (File.Exists(path))
        {
            data = File.ReadAllText(path);
        }
        else
        {
            Debug.LogWarning("Arquivo inexistente");
        }
    }
}
