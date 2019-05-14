using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteLamp : MonoBehaviour
{
    Vector3 position;

    public void Text()
    {
        Debug.Log(GameObject.Find("Lampada").GetComponent<RectTransform>().localPosition);
        Debug.Log(GameObject.Find("Lampada").transform.position);
        BallonTips.CreateBallonText("Aiaiaiaii que delicia", GameObject.Find("Lampada").GetComponent<RectTransform>().position);
    }
}
