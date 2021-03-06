﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LousaTextPageController : MonoBehaviour
{
    public DeafText[] text;
    public TextLousa textLousa;
    public Button next;
    public Button back;
    public LastTextButton lastTextButton;
    private int currentPage = 0;
    private int lastPage;
    
    private void Start()
    {
        lastPage = text.Length-1;
        StarText();
        CheckButtons();
    }

    public void StarText()
    {
        textLousa.InsertMainText(text[currentPage]);
    }

    public void NextPage()
    {
        currentPage++;
        textLousa.InsertMainText(text[currentPage]);
        CheckButtons();
    }

    public void BackPage()
    {
        currentPage--;
        textLousa.InsertMainText(text[currentPage]);
        CheckButtons();
    }

    private void CheckButtons()
    {
        if (currentPage == 0)
        {
            back.gameObject.SetActive(false);
        }
        else if (currentPage > 0 && currentPage < lastPage)
        {
            back.gameObject.SetActive(true);
            next.gameObject.SetActive(true);
        }
        else if (currentPage == lastPage)
        {
            next.gameObject.SetActive(false);
            lastTextButton.SetTrue();
        }
    }
}
