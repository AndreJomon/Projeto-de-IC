using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class AtomBox : MonoBehaviour {

    public GameObject atomo;
    private GameObject newAtomo;
    private int numAtomos;
    private int distance;

    void OnMouseDown()
    {
        InstanciarNovoAtomo();
    }

    private void InstanciarNovoAtomo()
    {
        if (Atomo.nAtomos <= 5 && !GameObject.FindGameObjectWithTag("Molecula"))
        {
            newAtomo = Instantiate(atomo, new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance), Quaternion.identity);
        }
    }


    private void OnMouseDrag()
    {
        if (Atomo.nAtomos <= 5 && !GameObject.FindGameObjectWithTag("Molecula"))
        {
            newAtomo.GetComponent<Atomo>().OnMouseDrag();
        }
    }

    private void OnMouseUp()
    {
        if (GameObject.FindGameObjectWithTag("Atomo"))
        {
            newAtomo.GetComponent<Atomo>().OnMouseUp();
        }
    }
}
