using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomBox : MonoBehaviour {

    public GameObject atomo;
    public GameObject newAtomo;

    void OnMouseDown()
    {
        newAtomo = Instantiate(atomo, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }

    private void OnMouseDrag()
    {
        newAtomo.GetComponent<DragOn>().OnMouseDrag();
    }

    ///Fazer ontrigger no objeto instanciado
    ///Triggar quando entra um booleano para não se autodestruir



}
