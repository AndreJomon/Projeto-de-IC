using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class VideoToPlayOnStart : MonoBehaviour {

    VideoManager videoManager;
    public VideoClip video;
    public RawImage tela;

    private void Start()
    {
        videoManager = VideoManager.instance;
        StartCoroutine(videoManager.PlayVideo(tela, video));
    }
}
