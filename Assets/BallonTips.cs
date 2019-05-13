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
        Debug.Log(RectTransformUtility.WorldToScreenPoint(Camera.main, lampPositionModifier));
        Debug.Log(lampPositionModifier);
        ballonTips = GameManager.instance.ballonTips;
        GameObject tempBallonTips = null;
        //lampPosition = Camera.main.WorldToScreenPoint(lampPosition);
        Debug.Log(lampPosition);
        Debug.Log(Camera.main.WorldToViewportPoint(lampPosition));
        Debug.Log(Camera.main.ScreenToWorldPoint(lampPosition));
        lampPosition.x += lampPositionModifier.x;
        lampPosition.y += lampPositionModifier.y;
        tempBallonTips = Instantiate(ballonTips, lampPosition, Quaternion.identity, GameObject.Find("Lampada").transform);
        tempBallonTips.GetComponent<BallonTips>().PutInfo(text);
        return tempBallonTips;
    }

    public void PutInfo(string text)
    {
        GetComponentInChildren<Text>().text = text;
    }
}
