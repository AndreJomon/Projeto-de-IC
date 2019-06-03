using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialButtonsQuiz : MonoBehaviour
{
    private Animator canvasAnimator;

    void Start()
    {
        canvasAnimator = GameObject.Find("Canvas").GetComponent<Animator>();
        QuizManager.instance.TurnOnTela1();
    }
    
    public void SetDifficultAndNextScreen(int dificulty)
    {
        QuizManager.instance.SetDificulty(dificulty);
        QuizManager.instance.TurnOnTela2();
        //código de setar a dificuldade aqui
        canvasAnimator.SetTrigger("difficult_out");
        QuizManager.instance.PlayInstructionVideo();
    }

    public void StartQuiz()
    {
        QuizManager.instance.TurnOnTela1();
        canvasAnimator.SetTrigger("comecar");
        QuizManager.instance.PrepareNewQuestion();
    }
}
