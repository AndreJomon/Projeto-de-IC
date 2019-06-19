using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMessage : MonoBehaviour
{
    public GameObject dotsBalloon;
    public GameObject messageBalloon;
    public DeafText balloonMessage;

    private GameObject instantiatedDotsBalloon;
    private GameObject instantiatedMessageBalloon;

    public void OnMouseEnter()
    {
        GameManager.instance.instantiatedDotsBalloon = Instantiate(dotsBalloon, gameObject.transform.parent);
    }

    public void OnMouseExit()
    {
        Destroy(GameManager.instance.instantiatedDotsBalloon);
    }

    public void OnMouseDown()
    {
        if (!GameManager.instance.GetTextBallonInstantiate())
        {
            GameManager.instance.instantiatedMessageBalloon = Instantiate(messageBalloon, gameObject.transform.parent);
            GameManager.instance.instantiatedMessageBalloon.GetComponentInChildren<UnityEngine.UI.Text>().text = balloonMessage.text;
            StartCoroutine(VideoManager.instance.PlayVideo(balloonMessage.video));
            GameManager.instance.SetTextBallonInstantiate(true);
        }
    }

    public void DestroyBalloon()
    {
        VideoManager.instance.videoPlayer.Stop();
        GameManager.instance.SetTextBallonInstantiate(false);
        Destroy(GameManager.instance.instantiatedMessageBalloon);
    }
}
