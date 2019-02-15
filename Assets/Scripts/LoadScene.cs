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

    public static void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        //Fazer função para parar o video manager =p
    }
}
