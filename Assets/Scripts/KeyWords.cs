using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWords : MonoBehaviour
{
    public List<KeyWord> keyWords;
    private GameObject currentTextBox;
    private bool textBoxInstatiated;

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
        currentTextBox = TextBox.CreateTextBox(kw.text, position, true);
        textBoxInstatiated = true;
    }

    public void DestroyWordText()
    {
        if (textBoxInstatiated)
        {
            currentTextBox.GetComponent<TextBox>().DestroyObject();
            textBoxInstatiated = false;
        }
    }
}
