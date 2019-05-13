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
    KeyWords kw;

    public void Awake()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmpT = this.GetComponent<TMP_Text>();
        kw = this.GetComponent<KeyWords>();
    }

    void LateUpdate()
    {
        currentWordIndex = TMP_TextUtilities.FindIntersectingWord(tmpT, Input.mousePosition, camera);
        
        if(currentWordIndex != -1 && !(currentWordIndex == wordIndex))
        {
            kw.DestroyWordText();
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3 (0, offset, 0);
            kw.ShowKeyWordText(tmp.textInfo.wordInfo[currentWordIndex].GetWord(), position);
            wordIndex = currentWordIndex;
        }
    }



    ///Fazer adaptação a multiplos strings e funções para deixar o texto mais bonito.
}
