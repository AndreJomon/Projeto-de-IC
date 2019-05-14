using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallonTips : MonoBehaviour
{
    [SerializeField]
    public static GameObject ballonTips;
    private static Vector2 lampPositionModifier = new Vector2(90,90); //Criado arbitrariamente a partir de testes

    public static GameObject CreateBallonText(string text, Vector3 lampPosition)
    {
        ballonTips = GameManager.instance.ballonTips;
        GameObject tempBallonTips;
        tempBallonTips = Instantiate(ballonTips, GameObject.Find("Lampada").transform);
        tempBallonTips.transform.localPosition += new Vector3(lampPositionModifier.x, lampPositionModifier.y, 0);
        tempBallonTips.GetComponent<BallonTips>().PutInfo(text);
        return tempBallonTips;
    }

    public void PutInfo(string text)
    {
        GetComponentInChildren<Text>().text = text;
    }


}
