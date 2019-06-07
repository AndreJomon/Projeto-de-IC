using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule : MonoBehaviour
{
    public int carga;
    public int massa;
    public bool destroy = true;
    private float distance = 10;
    public GameObject mesa;
    private int numParticule;

    public void Awake()
    {
        mesa = GameObject.FindGameObjectWithTag("Mesa");
    }

    /// <summary>
    /// Quando se clica no objeto
    /// </summary>
    public void OnMouseDown()
    {
        OnMouseDrag();
    }

    /// <summary>
    /// Quando se arrasta o objeto
    /// </summary>
    public void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    /// <summary>
    /// Quando o objeto entra na área apropriada.
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mesa"))
        {
            collision.gameObject.GetComponent<MesaMontarAtomo>().AdicionandoParticula(carga, massa);
            destroy = false;
            ParticuleBox.AlterarQntdParticula(1, carga);
            Debug.Log("Entrou");
        }
    }

    /// <summary>
    /// Quando objeto sai da área apropriada.
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mesa"))
        {
            collision.gameObject.GetComponent<MesaMontarAtomo>().RemovendoParticula(carga, massa);
            destroy = true;
            ParticuleBox.AlterarQntdParticula(-1, carga);
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
