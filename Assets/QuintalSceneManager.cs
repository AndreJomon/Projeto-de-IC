using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuintalSceneManager : MonoBehaviour
{
    public Animator anim;
    private int numberOfScreens = 4;

    public void ChangeToScreen(int nextScreen)
    {
        string screenName;

        for (int i = 1; numberOfScreens >= i; i++) ///Seta todos os booleanos do animator relacionados para false.
        {
            screenName = "Screen" + i.ToString();
            anim.SetBool(screenName, false);
        }

        screenName = "Screen" + nextScreen.ToString();
        anim.SetBool(screenName, true); ///Seta o correto para true
    }
}
