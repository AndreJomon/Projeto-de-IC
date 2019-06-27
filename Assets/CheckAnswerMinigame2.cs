using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckAnswerMinigame2 : MonoBehaviour
{
    public float time;
    private List<GameObject> potContent;
    private List<string> listOfMolecules = new List<string>(); ///Serve para saber se alguma molécula já foi contada
    public List<Animator> animators;
    public MiniGame2StartWarning warning;

    private void Start()
    {
        potContent = Pot.GetPots();
        ActiveButton();
    }

    public void OnClick()
    {
        Pot.SetVisualizable(false);
        int numberOfMolecules = 0; //Número de moléculas que são válidas
        int totalPoints = 0; //Pontuação total das moléculas validadas.

        for (int i = 0; i < potContent.Count; i++) {
            if (potContent[i] != null)
            {
                MoleculaMinigame2 moleculaInfo = potContent[i].GetComponent<MoleculaMinigame2>();

                if (!listOfMolecules.Contains(moleculaInfo.name))
                {
                    listOfMolecules.Add(moleculaInfo.name);
                    numberOfMolecules++;
                    totalPoints += moleculaInfo.points;
                    animators[i].SetBool("Encher", true);
                    if (moleculaInfo.flyable)
                    {
                        animators[i].SetBool("Voar", true);
                    }
                }
            }
        }

        ///Resultado da partida: Ganha uma pontuação e descobre se o jogador foi bem o suciente para considerar a parte como "passada".

        SaveManager.instance.player.SetScore(1, totalPoints); //Dá a pontuação mesmo se ele não considerar que terminou a parte

        if (numberOfMolecules > 2)
        {
            SaveManager.instance.player.SetBeatPartTrue(2);
            warning.Feedback("Passed");
        }
        else
        {
            warning.Feedback("Failed");
        }
        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(time);
        GetComponent<LoadScene>().SceneLoaderForButtons("EscolhaDeFase");
    }

    private void ActiveButton()
    {
        Debug.Log(potContent.Count);
        for (int i = 0; i < potContent.Count; i++)
        {
            if (potContent[i] != null)
            {
                gameObject.GetComponent<Button>().interactable = true;
                return;
            }
        }
    }
}
