using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePhaseSelect : LoadScene
{
    public int beatedPart;
    public string ifBeated;
    public string ifNotBeated;

    public void LoadCorrectStage()
    {
        if (SaveManager.instance.player.GetBeatPartStatus(beatedPart))
        {
            SceneLoader(ifBeated);
        }
        else
        {
            SceneLoader(ifNotBeated);
        }
    }
}
