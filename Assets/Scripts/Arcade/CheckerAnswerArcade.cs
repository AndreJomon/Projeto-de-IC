using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerAnswerArcade : MonoBehaviour
{
    public ConstrutorAtomo construtorAtomo;
    private GameManager gameManager;
    public GameObject button;

    private void Start()
    {
        gameManager = GameManager.instance;
        StartCoroutine(WaitToAppear());
    }

    public void CheckAnswer()
    {
        bool result = gameManager.CheckAnswerArcade(construtorAtomo.GetNumProtons(), construtorAtomo.GetNumEletrons(), construtorAtomo.GetNumNeutrons());
        if (result)
        {
            Debug.Log("Parabéns");
            SaveManager.instance.player.SetBeatPartTrue(1);
        }
        else
        {
            Debug.Log("Perdeu, lixo");
        }
    }

    private IEnumerator WaitToAppear()
    {
        yield return new WaitUntil(() => construtorAtomo.GetNumProtons() > 0);
        button.SetActive(true);
    }
}
