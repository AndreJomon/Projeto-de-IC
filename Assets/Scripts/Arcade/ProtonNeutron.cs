using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtonNeutron : Particule
{
    void Start()
    {
        areaManager = GameObject.Find("AreaProtons");
    }

    public void OnClick()
    {
        areaManager.GetComponent<MontarNucleo>().DeletedParticule(index);
        Destroy(gameObject);
    }
}
