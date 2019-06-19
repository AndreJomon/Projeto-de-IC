using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {
    public int potNumber;
    public static int currentPot = -1;
    private static List<GameObject> potContent = new List<GameObject>();

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
            ShowPotContent();
        }
    }

    private void ShowPotContent()
    {/*
        GameObject potContentTemp = Instantiate(potContent[potNumber], gameObject.transform);
        potContentTemp.transform.position = this.transform.position;
        potContentTemp.transform.localScale = new Vector3(0.5f, 0.5f, 1);*/
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
