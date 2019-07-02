using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcadeButton : MonoBehaviour
{
    public int limitParticules;
    public int numberParticules = 0;

    public void CheckAble()
    {
        numberParticules++;

        if (numberParticules == limitParticules)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void ParticuleDestroyed()
    {
        numberParticules--;
        CheckAble();
    }
}
