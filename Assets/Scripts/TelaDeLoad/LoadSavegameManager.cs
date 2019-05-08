using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSavegameManager : MonoBehaviour
{
    private SlotsList list;
    private List<int> usedSlots = new List<int>();
    private int listSize;
    [SerializeField]
    private GameObject loadButton;
    [SerializeField]
    private GameObject content;

    private void Awake()
    {
        list = SaveManager.instance.list;
        listSize = SaveManager.slotsListSize;
    }

    private void Start()
    {
        GameObject loadButtonTemp;
        FillUsedSlots();
        foreach (int i in usedSlots)
        {
            loadButtonTemp = Instantiate(loadButton, content.transform);
            loadButtonTemp.GetComponent<SavegameLoadButton>().GetInformation(i);
        }
    }

    private void FillUsedSlots()
    {
        for (int i = 0; i<listSize; i++)
        {
            if (!list.slotsList.Contains(i))
            {
                usedSlots.Add(i);
            }
        }
    }
}
