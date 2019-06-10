using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eletron : Particule
{
    void Start()
    {
        areaManager = GameObject.Find("AreaEletronsExterior");
    }

    public void OnClick()
    {
        areaManager.GetComponent<MontarEletroesfera>().DeletedParticule(index);
        Destroy(gameObject);
    }
}
