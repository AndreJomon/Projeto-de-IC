using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letterAnimation : MonoBehaviour {

    public int spinVelocity;
    public float upVelocity;
    public float goalUp;
    public float growth;
    private GameObject letter;
    private bool alreadyInstatiate = false;


    private void Awake()
    {
        letter = GameObject.Find("Letter");     
    }
    
    private void Update()
    {
        if (letter.transform.position.y < goalUp)
        {
            moveUp(letter.transform.position.y);
            zoomIn(letter.transform.localScale.x);
            Spinner();
        }
        else if (!alreadyInstatiate)
        {

            alreadyInstatiate = true;
        }
    }

    private void Spinner()
    {
        letter.transform.Rotate(new Vector3(0,0,spinVelocity) * Time.deltaTime);
    }

    private void moveUp(float moveUp)
    {
        moveUp += upVelocity;
        letter.transform.position = (new Vector3(letter.transform.position.x, moveUp, letter.transform.position.z));
    }

    private void zoomIn(float currentScale)
    {
        float scale = currentScale + growth; 
        letter.transform.localScale = new Vector3(scale, scale, scale);
    }

}
