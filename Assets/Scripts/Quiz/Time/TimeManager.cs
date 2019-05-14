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
        timerAnimation.RestarAnimation();
        count = repeatInstances;
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        //Debug.Log("Timer round " + repeatInstances + " " + Time.time);
        if (count > 0)
        {
            yield return new WaitForSeconds(timeToWait);
            count--;
            timerAnimation.NextTransition();
            timerCoroutineInstance = StartCoroutine(Timer());
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