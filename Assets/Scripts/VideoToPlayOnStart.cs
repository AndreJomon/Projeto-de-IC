using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class VideoToPlayOnStart : MonoBehaviour {

    VideoManager videoManager;
    public VideoClip video;

    private void Start()
    {
        videoManager = VideoManager.instance;
        videoManager.PlayVideo(video);
    }
}
