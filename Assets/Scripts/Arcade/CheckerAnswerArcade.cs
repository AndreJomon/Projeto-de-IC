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
        button.GetComponent<Button>().interactable = false;
        bool result = gameManager.CheckAnswerArcade(construtorAtomo.GetNumProtons(), construtorAtomo.GetNumEletrons(), construtorAtomo.GetNumNeutrons());
        if (result)
        {
            SaveManager.instance.player.SetBeatPartTrue(1);
            avisoArcade.GiveFeedback(1);
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
