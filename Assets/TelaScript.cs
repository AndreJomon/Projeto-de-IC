using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaScript : MonoBehaviour
{
    VideoManager videoManager;

    public void Start()
    {
        videoManager = VideoManager.instance;
    }

    public void OnMouseDown()
    {
        if (videoManager.VideoIsPlaying())
        {
            videoManager.PauseVideo();
        }


    }
}
