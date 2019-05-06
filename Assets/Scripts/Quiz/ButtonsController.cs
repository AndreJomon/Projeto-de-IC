using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonsController", menuName = "My Assets/Controlador de Botões")]
public class ButtonsController : ScriptableObject
{
    private int selectedButton = -1;

    /// <summary>
    /// Função que marca a alternativa selecionada para posterior verificação
    /// </summary>
    /// <param name="value"></param>
    public void ButtonPressed(int value)
    {
        selectedButton = value;

        UnselectAllButtons();
        GameObject.Find("Button Answer " + value).GetComponent<UnityEngine.UI.Button>().interactable = false;
    }

    /// <summary>
    /// Função que verifica se a resposta selecionada está correta
    /// </summary>
    public void ConfirmSelection()
    {
        UnselectAllButtons();
        QuizManager.instance.CheckAnswer(selectedButton);
    }

    /// <summary>
    /// Função que verifica automáticamente se a alternativa selecionada é a correta
    /// </summary>
    /// <param name="value"></param>
    public void AnswerSelected(int value)
    {
        UnselectAllButtons();
        GameObject.Find("Button Answer " + value).GetComponent<UnityEngine.UI.Button>().interactable = false;
        QuizManager.instance.CheckAnswer(value);
    }

    #region Funções auxiliares
    /// <summary>
    /// Função que desmarca todos os botões da tela
    /// </summary>
    private void UnselectAllButtons()
    {
        UnityEngine.UI.Button[] buttons = GameObject.FindObjectsOfType<UnityEngine.UI.Button>();

        foreach (UnityEngine.UI.Button button in buttons)
        {
            button.interactable = true;
        }
    }

    #endregion
}