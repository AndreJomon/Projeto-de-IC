using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class HelpClick : MonoBehaviour {

    Button handButton;
    VideoManager videoManager;
    public VideoClip video;
    public Sprite imagemBotaoOuvinte;
    public Sprite imagemBotaoSurdo;
    private static bool librasLigado = false;

    /// <summary>
    /// Elemento de texto que está sendo escrito, GameObject da caixa onde o texto está sendo escrito e Component "Text" do texto
    /// </summary>
    Text learnText;
    GameObject ballonText;
    LearningText learningText;



    private void Awake()
    {
        //handButton = GameObject.FindGameObjectWithTag("HandButton").GetComponent<Button>();
        handButton = GetComponent<Button>();
        //imagemBotaoOuvinte = (Resources.Load("Sprites/BotaoAjudaOuvinte") as Sprite);
        //imagemBotaoSurdo = (Resources.Load("Sprites/BotaoAjudaSurdo") as Sprite);
        learnText = GameObject.FindGameObjectWithTag("LearnText").GetComponent<Text>();
        ballonText = GameObject.FindGameObjectWithTag("BallonText");
    }

    private void Start()
    {
        videoManager = VideoManager.instance;
        learningText = LearningText.instance;
    }

    public void TrocarTextoPorVideo()
    {
        if (!librasLigado)
        {
            librasLigado = true;

            if (learningText.GetStillTyping())
            {
                learningText.TypeEverything();
            }

            learnText.enabled = false;
            ballonText.SetActive(false);

            videoManager.PlayVideo(ballonText.transform.position, video);

            handButton.GetComponent<Image>().sprite = imagemBotaoOuvinte;
        }
        else if (librasLigado)
        {
            videoManager.StopVideo();

            librasLigado = false;

            learnText.enabled = true;
            ballonText.SetActive(true);
            learningText.ButtonsAbleChecker();

            handButton.GetComponent<Image>().sprite = imagemBotaoSurdo;
        }
    }
}
