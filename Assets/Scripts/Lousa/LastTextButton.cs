using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LastTextButton : LoadScene
{
    private bool lastTextAppeared = false;

    public void SetTrue()
    {
        lastTextAppeared = true;
        ActiveObject();
    }

    private void ActiveObject()
    {
        GetComponent<Animator>().Play("PlacaDescendo");
    }

    public void TutorialEnded()
    {
        SaveManager.instance.player.SetBeatPartTrue(0);
    }
}
