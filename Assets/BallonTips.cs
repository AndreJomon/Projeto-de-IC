using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallonTips : MonoBehaviour
{
    [SerializeField]
    public static GameObject ballonTips;
    public static GameObject queijo;
    private static Vector2 lampPositionModifier = new Vector2(90,90); //Criado arbitrariamente a partir de testes

    public static GameObject CreateBallonText(string text, Vector3 lampPosition)
    {
        GameObject tempBallonTips;
        lampPosition.x += lampPositionModifier.x;
        lampPosition.y += lampPositionModifier.y;
        tempBallonTips = Instantiate(ballonTips, lampPosition, Quaternion.identity, GameObject.Find("Canvas").transform);
        tempBallonTips.GetComponent<BallonTips>().PutInfo(text);
        return tempBallonTips;
    }

    public void PutInfo(string text)
    {
        GetComponentInChildren<Text>().text = text;
    }
}
