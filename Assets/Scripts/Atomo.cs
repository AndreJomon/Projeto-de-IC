using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Atomo : MonoBehaviour {

    public string nome;
    public bool destroy = true;
    private float distance = 10;
    private GameObject mesa;

    public void Awake()
    {
        nome = nome.ToUpper();
        mesa = GameObject.Find("Mesa");
    }
    public void OnMouseDown()
    {
        OnMouseDrag();
    }

    public void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mesa"))
        {
            destroy = false;
            mesa.GetComponent<MesaScript>().resposta.Add(nome);
            Debug.Log(mesa.GetComponent<MesaScript>().resposta.Count);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mesa"))
        {
            destroy = true;
            mesa.GetComponent<MesaScript>().resposta.Remove(nome);
            Debug.Log(mesa.GetComponent<MesaScript>().resposta.Count);
        }
    }

    public void OnMouseUp()
    {
        if (destroy)
        {
            Destroy(gameObject);
        }
    }
}
