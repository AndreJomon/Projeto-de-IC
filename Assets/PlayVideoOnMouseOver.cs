using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnMouseOver : MonoBehaviour
{
    private VideoManager videoManager;
    public VideoClip video;

    private void Start()
    {
        videoManager = VideoManager.instance;
    }

    private void OnMouseEnter()
    {
        StartCoroutine(videoManager.PlayVideo(video));
    }
}
