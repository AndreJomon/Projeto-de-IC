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
    }
    
    public void SetDifficultAndNextScreen(int dificulty)
    {
        QuizManager.instance.SetDificulty(dificulty);
        //código de setar a dificuldade aqui
        canvasAnimator.SetTrigger("difficult_out");
    }

    public void StartQuiz()
    {
        canvasAnimator.SetTrigger("comecar");
        QuizManager.instance.PrepareNewQuestion();
    }
}
