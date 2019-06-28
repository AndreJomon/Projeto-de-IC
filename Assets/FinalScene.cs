using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{

    public GameObject gameObjectToAppear;
    public VideoClip video;
    public RawImage rawImage;
    public string nextScene;
    private int clickCount = 0;

    

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (clickCount == 0)
            {
                clickCount++;
                gameObjectToAppear.SetActive(true);
                StartCoroutine(VideoManager.instance.PlayVideo(video));
            }
            else
            {
                LoadScene.SceneLoader(nextScene);
            }
        }
    }
}
