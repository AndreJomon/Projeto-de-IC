using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HelpClick : MonoBehaviour {

    Button handButton; //Vai ser usado mais tarde
    VideoManager videoManager;
    public Sprite imagemBotaoOuvinte;
    public Sprite imagemBotaoSurdo;
    private static bool librasLigado = false;
    Text learnText;
    GameObject ballonText;
    Image buttonImage;



    private void Awake()
    {
        handButton = GameObject.FindGameObjectWithTag("HandButton").GetComponent<Button>();
        //imagemBotaoOuvinte = (Resources.Load("Sprites/BotaoAjudaOuvinte") as Sprite);
        //imagemBotaoSurdo = (Resources.Load("Sprites/BotaoAjudaSurdo") as Sprite);
        buttonImage = handButton.GetComponent<Image>();
        learnText = GameObject.FindGameObjectWithTag("LearnText").GetComponent<Text>();
        ballonText = GameObject.FindGameObjectWithTag("BallonText");
    }

    private void Start()
    {
        videoManager = VideoManager.instance;
    }

    public void TrocarTextoPorVideo()
    {
        /*Text learnText;
        GameObject ballonText;
        Image buttonImage;

        buttonImage = handButton.GetComponent<Image>();
        learnText = GameObject.FindGameObjectWithTag("LearnText").GetComponent<Text>();
        ballonText = GameObject.FindGameObjectWithTag("BallonText");*/

        if (!librasLigado)
        {
            librasLigado = true;

            learnText.enabled = false;
            ballonText.SetActive(false);

            videoManager.PlayVideo(ballonText.transform.position);

            handButton.GetComponent<Image>().sprite = imagemBotaoOuvinte;
        }
        else if (librasLigado)
        {
            videoManager.StopVideo();

            librasLigado = false;

            learnText.enabled = true;
            ballonText.SetActive(true);

            handButton.GetComponent<Image>().sprite = imagemBotaoSurdo;
        }
    }
}
