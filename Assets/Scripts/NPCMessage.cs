using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMessage : MonoBehaviour
{
    public GameObject dotsBalloon;
    public GameObject messageBalloon;
    public DeafText balloonMessage;
    public float posXAjust;
    public float posYAjust;

    private GameObject instantiatedDotsBalloon;
    private GameObject instantiatedMessageBalloon;
    
    public void OnMouseEnter()
    {
        if (!GameManager.instance.messageBalloonOn)
        {
            GameManager.instance.instantiatedDotsBalloon = Instantiate(dotsBalloon, gameObject.transform.parent);

            GameManager.instance.instantiatedDotsBalloon.transform.localPosition = 
                new Vector3(gameObject.transform.GetComponent<RectTransform>().offsetMax.x + posXAjust,
                gameObject.transform.GetComponent<RectTransform>().offsetMax.y + posYAjust, 0);

            Debug.Log(gameObject.transform.GetComponent<RectTransform>().offsetMax.x);
            Debug.Log(GameManager.instance.instantiatedDotsBalloon.transform.position);
        }
    }

    public void OnMouseExit()
    {
        Destroy(GameManager.instance.instantiatedDotsBalloon);
    }

    public void OnMouseDown()
    {
        GameManager.instance.messageBalloonOn = true;

        Destroy(GameManager.instance.instantiatedDotsBalloon);

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
        GameManager.instance.messageBalloonOn = false;
        VideoManager.instance.videoPlayer.Stop();
        GameManager.instance.SetTextBallonInstantiate(false);
        Destroy(GameManager.instance.instantiatedMessageBalloon);
    }
}
