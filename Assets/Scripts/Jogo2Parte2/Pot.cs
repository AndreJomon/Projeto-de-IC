using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {
    public int potNumber;
    public static int currentPot = -1;
    private static List<GameObject> potContent = new List<GameObject>();
    public GameObject conteudo;
    private static bool visualizable = true; //Saber se pode instanciar ou não o que há dentro do balão. 

    public static void SetVisualizable(bool valor)
    {
        visualizable = valor;
    }

    public static bool GetVisualizable()
    {
        return visualizable;
    }

    private void Awake()
    {
        if (potContent.Count == 0)
        {
            potContent.Add(null);
            potContent.Add(null);
            potContent.Add(null);
        }
    }

    private void Start()
    {
        if (potContent[potNumber] != null)
        {
            InstatiateContent();
        }
    }

    private void InstatiateContent()
    {
        GameObject potContentTemp = Instantiate(potContent[potNumber], conteudo.transform);
        potContentTemp.transform.localScale = new Vector3(14f, 14f, 1);
        Vector3 transformTemp = potContentTemp.transform.localPosition;
        potContentTemp.transform.localPosition = new Vector3(transformTemp.x, transformTemp.y+6, transformTemp.z);
    }

    private void OnMouseEnter()
    {
        ShowPotContent();
    }

    private void OnMouseExit()
    {
        HidePotContent();
    }

    private void ShowPotContent()
    {
        if (visualizable)
        {
            conteudo.SetActive(true);
        }
    }

    private void HidePotContent()
    {
        if (visualizable)
        {
            conteudo.SetActive(false);
        }
    }

    public static void PutOnPot(GameObject content, int potNumber)
    {
        potContent[potNumber] = content;
    }

    public static GameObject GetPotContent(int potNumber)
    {
        return potContent[potNumber];
    }

    public static List<GameObject> GetPots()
    {
        return potContent;
    }

    public void Click()
    {
        currentPot = potNumber;
        LoadScene.SceneLoader("Ligando atomos");
    }

}
