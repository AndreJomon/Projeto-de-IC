using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ProfButtonController", menuName = "My Assets/Professor Area Button Contrller")]
public class ProfButtonController : ScriptableObject
{
    private Player playerTemp;
    public static int selectedSlot = -1;

    public void ResumoDeJogadores()
    {
        DataManager.instance.PlayersSummary();

        Debug.Log(playerTemp.ToString());
    }

    public void RemovePlayer(SavegameLoadButton buttonInfo)
    {
        selectedSlot = buttonInfo.GetPlayer().GetSlot();
        GameObject.Find("AccessManager").GetComponent<ProfessorManager>().ConfirmPanel();
    }

    public void ConfirmDeletePlayer()
    {
        SaveManager.instance.DeletePlayer(selectedSlot);
        GameObject.Find("ConfirmPanel").SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CancelDeletePlayer()
    {
        GameObject.Find("ConfirmPanel").SetActive(false);
    }
}