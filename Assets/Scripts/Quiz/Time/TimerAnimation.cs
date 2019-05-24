using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAnimation : MonoBehaviour
{
    public Vector2 posInicial;
    public Vector2 posFinal;
    private Vector2 pos;
    private int count = 0;
    public GameObject movingObject;

    private float barProgression;

    private void Equation(float x)
    {
        pos.x = posInicial.x + x * (posFinal.x - posInicial.x) / TimeManager.instance.repeatInstances;
        pos.y = posInicial.y + x * (posFinal.x - posInicial.x) / TimeManager.instance.repeatInstances * ((posFinal.y - posInicial.y) / (posFinal.x - posInicial.x)) +
            Mathf.Sin(x * Mathf.PI / (TimeManager.instance.repeatInstances / 2)) * (posFinal.y - posInicial.y) / (TimeManager.instance.repeatInstances / 4);
    }

    private IEnumerator Animation_MovingEletron()
    {
        Equation(count);
        Debug.Log(pos);
        movingObject.transform.localPosition = new Vector3(pos.x, pos.y);
        count++;
        yield return new WaitForSeconds(0);
    }

    public IEnumerator Animation()
    {
        yield return new WaitForSeconds(0);
    }

    public void RestarAnimation()
    {
        count = 0;
        StartCoroutine(Animation_MovingEletron());
        //StartCoroutine(Animation());
    }

    public void NextTransition()
    {
        StartCoroutine(Animation_MovingEletron());
        //StartCoroutine(Animation());
    }
}
