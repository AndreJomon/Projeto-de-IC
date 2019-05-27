using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        gameObject.SetActive(lastTextAppeared);
    }
}
