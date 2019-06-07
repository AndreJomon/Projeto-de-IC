using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour
{
    public GameObject proton, eletron, neutron;
    private Vector3 shootSpawnLocation;

    private void Start()
    {
        shootSpawnLocation = GetComponentInChildren<Transform>().position;
    }

    private void Shoot(GameObject particule)
    {
        Instantiate(particule, gameObject.transform.position, Quaternion.identity, transform);
    }

    public void ShootProton()
    {
        Shoot(proton);
    }

    public void ShootEletron()
    {
        Shoot(eletron);
    }

    public void ShootNeutron()
    {
        Shoot(neutron);
    }
}
