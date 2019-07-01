using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class VideoManager : MonoBehaviour {

    public static VideoManager instance = null;
    public VideoPlayer videoPlayer;
    public VideoClip mainVideo;
    private bool videoEnded;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(this != instance)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator PlayVideo()
    {
        yield return new WaitUntil(() => videoPlayer.isPrepared);
        videoPlayer.Play();
    }

    public IEnumerator PlayVideo (RawImage image)
    {
        StartCoroutine(PlayVideo(image, videoPlayer.clip, true));
        yield return new WaitForSeconds(0);
    }

    public IEnumerator PlayVideo(VideoClip video)
    {
        StartCoroutine(PlayVideo(GameObject.Find("Tela").GetComponent<RawImage>(), video, true));
        yield return new WaitForSeconds(0);
    }

    public IEnumerator PlayVideoHelper(VideoClip video)
    {
        StartCoroutine(PlayVideo(GameObject.Find("Tela").GetComponent<RawImage>(), video, false));
        yield return new WaitForSeconds(0);
    }

    public IEnumerator PlayVideo(RawImage image, VideoClip video)
    {
        StartCoroutine(PlayVideo(image, video, true));
        yield return new WaitForSeconds(0);
    }

    public IEnumerator PlayVideo(RawImage image, VideoClip video, bool isMainVideo)
    {
        videoPlayer.clip = video;
        if (isMainVideo)
        {
            mainVideo = video;
        }
        videoPlayer.Prepare();
        yield return new WaitUntil(() => videoPlayer.isPrepared);
        image.texture = videoPlayer.texture;
        StartCoroutine(PlayVideo());
        WaitVideoEnding();
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }

    public void ReplayVideo()
    {
        videoPlayer.Stop();
        StartCoroutine(PlayVideo(mainVideo));
        WaitVideoEnding();
    }

    public bool VideoIsPlaying()
    {
        return videoPlayer.isPlaying;
    }

    public bool VideoEnded()
    {
        return videoEnded;
    }

    public void WaitVideoEnding()
    {
        videoEnded = false;
        videoPlayer.loopPointReached += EndReached; 
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        videoEnded = true;
        videoPlayer.loopPointReached -= EndReached;
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }
}
