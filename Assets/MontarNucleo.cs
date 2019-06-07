using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontarNucleo : MonoBehaviour
{
    //List<GameObject> particule

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Proton"))
        {
            Destroy(collision.gameObject);
        }

        else if (collision.CompareTag("Neutron"))
        {
            Destroy(collision.gameObject);
        }
    }

    //Vector3.MoveTowards
}
