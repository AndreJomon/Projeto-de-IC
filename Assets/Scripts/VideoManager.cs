using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class VideoManager : MonoBehaviour {

    public static VideoManager instance = null;
    public VideoPlayer videoPlayer;
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
        PlayVideo(image, videoPlayer.clip);
        yield return new WaitForSeconds(0);
    }

    public IEnumerator PlayVideo(RawImage image, VideoClip video)
    {
        videoPlayer.clip = video;
        videoPlayer.Prepare();
        yield return new WaitUntil(() => videoPlayer.isPrepared);
        image.texture = videoPlayer.texture;
        videoPlayer.Play();
        WaitVideoEnding();
    }

    public IEnumerator PlayVideo(VideoClip video)
    {
        PlayVideo(GameObject.Find("Tela").GetComponent<RawImage>(), video);
        yield return new WaitForSeconds(0);
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }

    public void ReplayVideo()
    {
        videoPlayer.Stop();
        videoPlayer.Play();
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
        Debug.Log("Video acabou");
        videoPlayer.loopPointReached -= EndReached;
    }

}
