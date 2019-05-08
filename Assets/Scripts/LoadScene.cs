using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    VideoManager videoManager;

    private void Awake()
    {
        videoManager = VideoManager.instance;
    }

    public static void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        //Fazer função para parar o video manager =p
    }

    public void SceneLoaderForButtons(string sceneName)
    {
        SceneLoader(sceneName);
    }
}
