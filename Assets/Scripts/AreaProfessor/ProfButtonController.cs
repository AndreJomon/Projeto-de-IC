using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProfButtonController", menuName = "My Assets/Professor Area Button Contrller")]
public class ProfButtonController : ScriptableObject
{
    private Player playerTemp;
    public static int selectedSlot = -1;
    
    public void ResumoDeJogadores()
    {
        DataManager.SelectProperFile();

        for (int i = 0; i < SaveManager.slotsListSize; i++)
        {
            if (!SaveManager.instance.list.slotsList.Contains(i))
            {
                playerTemp = SaveManager.instance.LoadPlayer(i);
                DataManager.statisticsData.SetValues(playerTemp);
                DataManager.SaveStatistics();
            }
        }
    }

    public void RemovePlayer()
    {

    }

    public void SelectedPlayerSlot()
    {
        
    }
}
