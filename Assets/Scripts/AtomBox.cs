﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomBox : MonoBehaviour {

    public GameObject atomo;
    private GameObject newAtomo;
    private int numAtomos;
    private int distance;

    void OnMouseDown()
    {
        newAtomo = Instantiate(atomo, new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance), Quaternion.identity);
    }

    private void OnMouseDrag()
    {
        newAtomo.GetComponent<Atomo>().OnMouseDrag();
    }

    private void OnMouseUp()
    {
        newAtomo.GetComponent<Atomo>().OnMouseUp();
    }
}
