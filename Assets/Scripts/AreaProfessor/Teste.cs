using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Teste : MonoBehaviour
{
    private void Start()
    {
        string path = Application.persistentDataPath + "/PlanilhaTeste.csv";

        StreamWriter sw = File.CreateText(path);
        string data = "a,b,c,d\n";
        data += "f\nkkk";

        sw.WriteLine(data);

        sw.Close();
    }
}
