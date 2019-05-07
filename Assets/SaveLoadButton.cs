using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadButton : MonoBehaviour
{
    Player playerTemp;
    GameObject nameText, classroomText, rankingPosition;

    public void GetInformation(int i)
    {
        playerTemp = SaveManager.instance.LoadPlayer(i);
        nameText.GetComponent<Text>().text = playerTemp.GetNome();
        classroomText.GetComponent<Text>().text = playerTemp.GetClassroom();
        rankingPosition.GetComponent<Text>().text = playerTemp.GetRankingPosition().ToString();
    }
}
