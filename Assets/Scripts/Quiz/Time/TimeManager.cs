using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TimeManager instance;
    public float timeToWait;
    public int repeatInstances;
    private int count;

    // Variável usada para armazenar uma referencia a corrotina (que deve ser interrompida caso necessário)
    private Coroutine timerCoroutineInstance = null;

    public TimerAnimation timerAnimation;

    public UnityEngine.UI.Image progressionBar;
    public float totalTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StartTimer()
    {
        progressionBar.fillAmount = 1;

        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        if (progressionBar.fillAmount > 0)
        {
            progressionBar.fillAmount -= (Time.deltaTime / totalTime);
            yield return new WaitForEndOfFrame();
            timerCoroutineInstance = StartCoroutine(Timer());
        }
        else
        {
            StartCoroutine(EndOfTime());
        }
    }

    public void StartTimer_MovingEletron()
    {
        timerAnimation.RestarAnimation();
        count = repeatInstances;
        StartCoroutine(Timer_MovingEletron());
    }
    
    public IEnumerator Timer_MovingEletron()
    {
        //Debug.Log("Timer round " + repeatInstances + " " + Time.time);
        if (count > 0)
        {
            yield return new WaitForSeconds(timeToWait);
            count--;
            timerAnimation.NextTransition();
            timerCoroutineInstance = StartCoroutine(Timer_MovingEletron());
        }
        else
        {
            StartCoroutine(EndOfTime());
        }
    }

    public IEnumerator EndOfTime()
    {
        //Debug.Log("Fim do timer");
        StartCoroutine(QuizManager.TimeOver());
        yield return new WaitForSeconds(0);
    }

    public void EndTimer()
    {
        //Debug.Log("Timer stopped");
        StopCoroutine(timerCoroutineInstance);
    }
}