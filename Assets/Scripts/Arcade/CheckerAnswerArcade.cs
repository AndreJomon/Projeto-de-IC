using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckerAnswerArcade : MonoBehaviour
{
    public ConstrutorAtomo construtorAtomo;
    private GameManager gameManager;
    public GameObject button;
    public int time;
    public AvisoArcade avisoArcade;

    private void Start()
    {
        gameManager = GameManager.instance;
        StartCoroutine(WaitToAppear());
    }

    public void CheckAnswer()
    {
        SaveManager saveManager = SaveManager.instance;
        button.GetComponent<Button>().interactable = false;

        bool [] result = gameManager.CheckAnswerArcade(construtorAtomo.GetNumProtons(), construtorAtomo.GetNumEletrons(), construtorAtomo.GetNumNeutrons());

        if (result[0]) //Checa somente os prótons, caso ele erre os prótons, errou a partícula inteira
        {
            saveManager.player.SetBeatPartTrue(1);

            if (result[1] && result[2]) //Acertou tudo;
            {
                saveManager.player.SetScore(1, 300);
                avisoArcade.GiveFeedback(1);
            }

            else if (result[1] || result[2]) //Acertou só um dos dois, além de ter acertado prótons
            {
                saveManager.player.SetScore(1, 150);
                avisoArcade.GiveFeedback(0);
            }

            else //Só acertou prótons;
            {
                avisoArcade.GiveFeedback(0);
                saveManager.player.SetScore(1, 50);
            }
        }

        else
        {
            avisoArcade.GiveFeedback(-1);
        }
        StartCoroutine(GoToNextScreen());
    }

    private IEnumerator WaitToAppear()
    {
        yield return new WaitUntil(() => construtorAtomo.GetNumProtons() > 0);
        button.SetActive(true);
    }

    private IEnumerator GoToNextScreen()
    {
        yield return new WaitForSeconds(time);
        if (SaveManager.instance.player.GetBeatPartStatus(0))
        {
            gameObject.GetComponent<LoadScene>().SceneLoaderForButtons("EscolhaDeFase");
        }
        else
        {
            gameObject.GetComponent<LoadScene>().SceneLoaderForButtons("Lousa2");
        }
    }
}
