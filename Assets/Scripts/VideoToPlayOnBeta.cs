using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class VideoToPlayOnBeta : MonoBehaviour {
    VideoManager videoManager;
    public VideoClip video;

    private void Start()
    {
        videoManager = VideoManager.instance;
        videoManager.PlayVideo(this.transform.position, video);
    }
}
