using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAtom : MonoBehaviour
{
    private GameManager gameManager;
    private string correctAtomName;
    public TextController textController;

    private void Start()
    {
        gameManager = GameManager.instance;
        ChoiceRandom();
        SetAtomNameOnText();
    }

    private void ChoiceRandom()
    {
        gameManager.correctAtomNumber = Random.Range(0, gameManager.GetNumberOfAtoms()-1);
        correctAtomName = gameManager.GetCorrectAtomName();
    }

    private void SetAtomNameOnText()
    {
        textController.text[1].text = "Tente montar um átomo de " + correctAtomName.ToUpper() + ".";
    }
}
