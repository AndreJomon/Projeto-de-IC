using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject ballonTips;
    /// <summary>
    /// Flag que controla se um texto já foi instanciado, ou seja, se já há um balão na tela.
    /// </summary>
    private bool textBallonInstantiate = false;

    public bool GetTextBallonInstantiate()
    {
        return textBallonInstantiate;
    }

    public void SetTextBallonInstantiate(bool textBallonInstantiate)
    {
        this.textBallonInstantiate = textBallonInstantiate;
    }

    #region Loader
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeManagers()
    {
        GameObject gameManager, saveManager, videoManager, soundManager;

        gameManager = Resources.Load("Prefabs/Managers/GameManager") as GameObject;

        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        saveManager = Resources.Load("Prefabs/Managers/SaveManager") as GameObject;

        if (SaveManager.instance == null)
        {
            Instantiate(saveManager);
        }

        videoManager = Resources.Load("Prefabs/Managers/VideoManager") as GameObject;

        if (VideoManager.instance == null)
        {
            Instantiate(videoManager);
        }

        soundManager = Resources.Load("Prefabs/Managers/SoundManager") as GameObject;

        if (SoundManager.instance == null)
        {
            Instantiate(soundManager);
        }

    }
    #endregion

    /// <summary>
    /// Instancia um balão de fala. Serve para mostrar as dicas.
    /// </summary>
    /// <param name="text">Texto que será exibido dentro do balão</param>
    /// <returns></returns>
    public GameObject CreateBallonText(string text)
    {
        GameObject tempBallonTips = null;

        if (!textBallonInstantiate) ///Caso o balão não esteja instanciado, instancia um.
        {
            SetTextBallonInstantiate(true);

            Vector2 positionModifier = ballonTips.GetComponent<BallonTips>().GetPositionModifier();

            tempBallonTips = Instantiate(ballonTips, GameObject.Find("Lampada").transform);
            tempBallonTips.transform.localPosition += new Vector3(positionModifier.x, positionModifier.y, 0);

            tempBallonTips.GetComponent<BallonTips>().PutInfo(text);
        }

        else ///Caso ele esteja, deleta o balão que está instanciado e chama a função novamente.
        {
            GameObject ballonText = GameObject.FindGameObjectWithTag("BallonText");
            ballonText.GetComponent<BallonTips>().AutoDestroy();
            CreateBallonText(text);
        }

        return tempBallonTips;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void OnApplicationQuit()
    {
        SaveManager.instance.Save();
    }
}
