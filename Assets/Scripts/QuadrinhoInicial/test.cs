using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject[] white;
    public GameObject zoom;
    public GameObject bigLetter;
    public Animator animator;

    public void ToggleScreen(int q)
    {
        white[q].SetActive(false);

        if (q == 2)
        {
            zoom.SetActive(true);
        }
        else
        {
            zoom.SetActive(false);
        }
    }

    public void OffButton(GameObject button)
    {
        button.SetActive(false);
    }

    public void Zoom()
    {
        bigLetter.SetActive(true);
    }

    public void ZoomOff()
    {
        bigLetter.SetActive(false);
    }

    public void ToggleOff(GameObject item)
    {
        item.SetActive(false);
    }

    public void ToggleOn(GameObject item)
    {
        item.SetActive(true);
    }
    
    public void SetToggle(string i)
    {
        animator.SetTrigger("toQ" + i);
    }
}
