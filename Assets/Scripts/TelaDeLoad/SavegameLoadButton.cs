using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavegameLoadButton : MonoBehaviour
{
    Player playerTemp;
    [SerializeField]
    GameObject nameText, classroomText;

    /// <summary>
    /// Recebe o slot do player que ele precisa carregar e atualiza as informações da prefab
    /// </summary>
    /// <param name="i"></param>
    public void GetInformation(int i)
    {
        playerTemp = SaveManager.instance.LoadPlayer(i);
        nameText.GetComponent<Text>().text = playerTemp.GetNome();
        classroomText.GetComponent<Text>().text = playerTemp.GetClassroom();
    }

    public void GetClicked()
    {
        SaveManager.instance.player.SetAll(playerTemp.GetSlot(), playerTemp.GetNome(), playerTemp.GetClassroom(), playerTemp.GetScore());
    }

    public Player GetPlayer()
    {
        return playerTemp;
    }
}
