using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyWord : DeafText
{
    public string name;
}

public class KeyWords: MonoBehaviour
{
    public List<KeyWord> keyWords;

    public void ShowKeyWordText(string text, Vector3 position)
    {
        foreach (KeyWord kw in keyWords)
        {
            if (kw.name == text)
            {
                InstatiateKeyWord(kw, position);
            }
        }
    }

    private void InstatiateKeyWord(KeyWord kw, Vector3 position)
    {
        TextBox.CreateTextBox(kw.text, position);
    }
}
