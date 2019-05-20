using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class TextLousa : MonoBehaviour
{
    public Camera camera;
    public float offset;
    private TMP_Text tmpT;
    private TextMeshProUGUI tmp;
    private int wordIndex = -2;
    private int currentWordIndex;
    private string[] text;

    public void Awake()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmpT = this.GetComponent<TMP_Text>();
        SplitString();

    }

    private void SplitString()
    {
        text = tmpT.text.Split(' ');
        
        for (int i = 0; i<text.Length; i++)
        {
            text[i] = text[i].TrimEnd(new char[] { ',', '.' });
        }
    }

    void LateUpdate()
    {
        currentWordIndex = TMP_TextUtilities.FindIntersectingWord(tmpT, Input.mousePosition, camera);
        
        if(currentWordIndex != -1 && !(currentWordIndex == wordIndex))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3 (0, offset, 0);
            wordIndex = currentWordIndex;
            Debug.Log(wordIndex.ToString() + ": " + text[wordIndex]);
        }
    }    ///Fazer adaptação a multiplos strings e funções para deixar o texto mais bonito.
}
