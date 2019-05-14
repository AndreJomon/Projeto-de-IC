using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class BallonTips : MonoBehaviour
{
    /// <summary>
    /// Criado arbitrariamente a partir de testes, serve para instanciar o objeto a uma distância "boa" do objeto base.
    /// </summary>
    [SerializeField]
    private Vector2 positionModifier = new Vector2(90,90);
    /// <summary>
    /// Tempo que demorará para o balão desaparecer
    /// </summary>
    [SerializeField]
    private int timeToDisappear = 10;
    public Animator anim;

    private void Start()
    {
        StartCoroutine(Disappearing());
    }

    public Vector2 GetPositionModifier()
    {
        return positionModifier;
    }

    /// <summary>
    /// Aplica as mudanças dentro do objeto.
    /// </summary>
    /// <param name="text"></param>
    public void PutInfo(string text)
    {
        GetComponentInChildren<Text>().text = text;
    }

    /// <summary>
    /// Espera um tempo X e ativa o trigger "disappear"
    /// </summary>
    /// <returns></returns>
    public IEnumerator Disappearing()
    {
        yield return new WaitForSeconds(timeToDisappear);
        anim.SetTrigger("Disappear");
    }

    /// <summary>
    /// É chamado pela animação de desaparecimento, destrói o objeto.
    /// </summary>
    public void AutoDestroy()
    {
        Destroy(gameObject);
    }

}
