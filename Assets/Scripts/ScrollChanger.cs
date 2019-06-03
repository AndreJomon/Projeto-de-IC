using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollChanger : MonoBehaviour
{
    public GameObject scrollBar;
    public float changeValor;

    public void ChangeValue()
    {
        scrollBar.GetComponent<Scrollbar>().value += changeValor;
    }
}
