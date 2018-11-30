using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    public bool temVersoes;
    public string sceneName;
    GameManager gameManager;
    VideoManager videoManager;

    private void Awake()
    {
        gameManager = GameManager.instance;
        videoManager = VideoManager.instance;
    }

    public void SceneLoad()
    {
        if (temVersoes)
        {
            if (gameManager.GetStyleManager().Equals("Alpha"))
            {
                SceneManager.LoadScene(sceneName + "Alpha", LoadSceneMode.Single);
            }
            else if (gameManager.GetStyleManager().Equals("Beta"))
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
