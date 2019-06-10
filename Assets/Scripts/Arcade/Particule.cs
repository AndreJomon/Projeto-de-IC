using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule : MonoBehaviour
{
    public int carga;
    public int massa;
    public float speed = 2;
    public Vector3 targetPosition;
    protected int index = -1;
    protected GameObject areaManager;

    public void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    public Vector3 GetTargetPosition()
    {
        return targetPosition;
    }

    public void SetIndex(int i)
    {
        index = i;
    }

    public int GetIndex()
    {
        return index;
    }

    private void Update()
    {
        if (transform.position != targetPosition)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }

    public int GetCarga()
    {
        return carga;
    }

    public int GetMassa()
    {
        return massa;
    }
}
