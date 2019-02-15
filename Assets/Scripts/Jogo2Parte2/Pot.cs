using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour {
    public int potNumber;
    public static int currentPot = -1;
    private static List<GameObject> potContent;

    private void Awake()
    {
        if (potContent == null)
        {
            potContent = new List<GameObject>();
        }
        potContent.Add(null);
    }

    private void Start()
    {
        if (potContent[potNumber] != null)
        {
            ShowPotContent();
        }
    }

    private void ShowPotContent()
    {
        GameObject potContentTemp = Instantiate(potContent[potNumber], GameObject.Find("Canvas").transform);
        potContentTemp.transform.position = this.transform.position;
        potContentTemp.transform.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    public static void PutOnPot(GameObject content, int potNumber)
    {
        potContent[potNumber] = content;
    }

    public void Click()
    {
        currentPot = potNumber;
        LoadScene.SceneLoad("Ligando atomos");
    }

}
