using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteLamp : MonoBehaviour
{
    Vector3 position;

    public void Text()
    {
        BallonTips.CreateBallonText("Aiaiaiaii que delicia", GameObject.Find("Lampada").transform.position);
    }
}
