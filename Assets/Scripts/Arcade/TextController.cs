using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text textShowing;
    public DeafText[] text;
    public Button nextPage;
    public Button previousPage;
    public LastTextButton lastTextButton;
    private int lastPage;
    private int currentPage = 0;

    private void Start()
    {
        lastPage = text.Length - 1;
        StarText();
        CheckButtons();
    }

    public void StarText()
    {
        InsertText(text[currentPage].text);
    }

    public void NextPage()
    {
        currentPage++;
        InsertText(text[currentPage].text);
        CheckButtons();
    }

    public void BackPage()
    {
        currentPage--;
        InsertText(text[currentPage].text);
        CheckButtons();
    }

    private void CheckButtons()
    {
        if (lastPage != 0  && currentPage == 0)
        {
            previousPage.gameObject.SetActive(false);
            nextPage.gameObject.SetActive(true);
        }
        else if (currentPage == 0)
        {
            previousPage.gameObject.SetActive(false);
        }
        else if (currentPage > 0)
        {
            previousPage.gameObject.SetActive(true);
            nextPage.gameObject.SetActive(true);
        }
        if (currentPage == lastPage)
        {
            Debug.Log("Entrou no ultimo");
            lastTextButton.SetTrue();
            nextPage.gameObject.SetActive(false);
        }
    }

    private void InsertText(string text)
    {
        textShowing.text = text;
    }
}
