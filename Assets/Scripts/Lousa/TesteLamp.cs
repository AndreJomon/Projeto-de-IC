using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteLamp : MonoBehaviour
{
    Vector3 position;

    public void Text()
    {
        GameObject.Find("Lampada").GetComponent<LampScript>().TurnOnLamp("Queijo");
    }
}
