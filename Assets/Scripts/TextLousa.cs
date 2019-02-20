using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class TextLousa : MonoBehaviour
{
    public Camera camera;
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
            kw.ShowKeyWordText(tmp.textInfo.wordInfo[currentWordIndex].GetWord(), Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //Debug.Log(currentWordIndex);
            //Debug.Log(tmp.textInfo.wordInfo[currentWordIndex].GetWord());
            wordIndex = currentWordIndex;
        }
    }
}
