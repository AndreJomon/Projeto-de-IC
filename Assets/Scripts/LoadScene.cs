using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    public string sceneName;
    VideoManager videoManager;

    private void Awake()
    {
        videoManager = VideoManager.instance;
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
