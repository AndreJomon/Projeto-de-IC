using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvisoArcade: MonoBehaviour
{
    [SerializeField] private DeafText[] feedbackAcerto;
    [SerializeField] private Color32 corAcerto;
    [SerializeField] private DeafText feedbackErro;
    [SerializeField] private Color32 corErro;
    [SerializeField] private DeafText feedbackMeioAcerto;
    [SerializeField] private Text text;
    private VideoManager videoManager;
    private GameManager gameManager;

    private void Start()
    {
        videoManager = VideoManager.instance;
        gameManager = GameManager.instance;
    }

    /// <summary>
    /// Dá o feedback para o jogador na tela de arcade de acordo com o inteiro dado:
    /// -1: Jogador errou
    /// 0: Montou um átomo que existe, mas não o que era para ser
    /// 1: Acertou
    /// </summary>
    /// <param name="i"></param>
    public void GiveFeedback(int i)
    {
        switch (i)
        {
            case -1:
                ChangeText(feedbackErro, corErro);
                break;

            case 0:
                ChangeText(feedbackMeioAcerto, corAcerto);
                break;

            case 1:
                feedbackAcerto[gameManager.correctAtomNumber].text = "Parabéns você montou o " + gameManager.GetCorrectAtomName();
                ChangeText(feedbackAcerto[gameManager.correctAtomNumber], corAcerto);
                break;
        }
    }

    private void ChangeText(DeafText deafText, Color32 color)
    {
        text.color = color;
        text.text = deafText.text;
        videoManager.PlayVideo(deafText.video);
    }
}
