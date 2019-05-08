using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Loader : MonoBehaviour {
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeManagers()
    {
        GameObject videoManager, gameManager, saveManager;

        videoManager = Resources.Load("Prefabs/Managers/VideoManager") as GameObject;
        gameManager = Resources.Load("Prefabs/Managers/GameManager") as GameObject;
        saveManager = Resources.Load("Prefabs/Managers/SaveManager") as GameObject;

        if (VideoManager.instance == null)
        {
            Instantiate(videoManager);
        }

        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if (SaveManager.instance == null)
        {
            Instantiate(saveManager);
        }
    }
}
