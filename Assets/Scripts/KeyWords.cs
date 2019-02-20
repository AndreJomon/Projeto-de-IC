using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWords : MonoBehaviour
{
    public List<KeyWord> keyWords;

    public void ShowKeyWordText(string text, Vector3 position)
    {
        foreach (KeyWord kw in keyWords)
        {
            if (kw.name.ToUpper() == text.ToUpper())
            {
                InstatiateKeyWord(kw, position);
            }
        }
    }

    private void InstatiateKeyWord(KeyWord kw, Vector3 position)
    {
        TextBox.CreateTextBox(kw.text, position);
    }

    public void DestroyWordText()
    {
        //If find...
    }
}
