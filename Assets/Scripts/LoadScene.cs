using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    public bool temVersoes;
    public string sceneName;
    VideoManager videoManager;

    private void Awake()
    {
        videoManager = VideoManager.instance;
    }

    public void SceneLoad()
    {
        if (temVersoes)
        {
            if (PlayerPrefs.GetString("Style", "Alpha").Equals("Alpha"))
            {
                SceneManager.LoadScene(sceneName + "Alpha", LoadSceneMode.Single);
            }
            else if (PlayerPrefs.GetString("Style", "Alpha").Equals("Beta"))
            {
                SceneManager.LoadScene(sceneName + "Beta", LoadSceneMode.Single);
            }
        }
        else
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        videoManager.SetAlreadyInstatiate(false);
    }
}
