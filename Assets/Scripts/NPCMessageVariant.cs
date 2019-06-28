using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMessageVariant : NPCMessage
{
    public DeafText alterMessage;
    public GameObject botaoBolo;

    private void Start()
    {
        Player tempPlayer = SaveManager.instance.player;

        if (tempPlayer.GetBeatPartStatus(0) && tempPlayer.GetBeatPartStatus(1) && tempPlayer.GetBeatPartStatus(2) && tempPlayer.GetBeatPartStatus(3))
        {
            balloonMessage = alterMessage;
            botaoBolo.SetActive(true);
        }
    }
}
