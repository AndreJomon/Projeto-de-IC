using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomBox : MonoBehaviour {

    public GameObject atomo;
    private GameObject newAtomo;
    private int distance;

    void OnMouseDown()
    {
        newAtomo = Instantiate(atomo, new Vector3(Input.mousePosition.x, Input.mousePosition.y/*gameObject.transform.position.x, gameObject.transform.position.y*/ , distance), Quaternion.identity);
    }

    private void OnMouseDrag()
    {
        newAtomo.GetComponent<DragOn>().OnMouseDrag();
    }

    ///Fazer ontrigger no objeto instanciado
    ///Triggar quando entra um booleano para não se autodestruir



}
