using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class DragOn : MonoBehaviour {

    public bool destroy = true;
    float distance = 10;

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
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mesa"))
        {
            destroy = true;
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
