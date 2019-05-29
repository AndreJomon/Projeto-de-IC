using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe que controla os botões do painel do professor
/// </summary>
[CreateAssetMenu(fileName = "ProfButtonController", menuName = "My Assets/Professor Area Button Contrller")]
public class ProfButtonController : ScriptableObject
{
    private Player playerTemp;
    public static int selectedSlot = -1;

    /// <summary>
    /// Função que gera o resumo dos jogadores em um arquivo externo
    /// </summary>
    public void ResumoDeJogadores()
    {
        DataManager.instance.PlayersSummary();
    }

    /// <summary>
    /// Função que armazena o slot selecionado e chama o painel de confirmação para deletar o player do slot
    /// </summary>
    /// <param name="buttonInfo"></param>
    public void RemovePlayer(SavegameLoadButton buttonInfo)
    {
        selectedSlot = buttonInfo.GetPlayer().GetSlot();
        GameObject.Find("AccessManager").GetComponent<ProfessorManager>().ConfirmPanel();
    }

    /// <summary>
    /// Função que remove o player selecionado e atualiza a tela
    /// </summary>
    public void ConfirmDeletePlayer()
    {
        SaveManager.instance.DeletePlayer(selectedSlot);
        GameObject.Find("ConfirmPanel").SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Cancela a remoção do jogador e remove o painel de confirmação
    /// </summary>
    public void CancelDeletePlayer()
    {
        GameObject.Find("ConfirmPanel").SetActive(false);
    }
}