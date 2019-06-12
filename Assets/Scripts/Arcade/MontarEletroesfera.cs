using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontarEletroesfera : MonoBehaviour
{
    public ConstrutorAtomo construtorAtomo;
    public GameObject particuleFather; //Objeto pai da lista de posições das partículas.
    public GameObject eletron; //Prefab dos tipos de partículas
    public List<Vector3> particulePositionTarget = new List<Vector3>(); //Lista de vetores que são as posições que as partículas devem ter.
    private GameObject[] particuleList; //Lista de gameobjects de partículas instanciadas.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Eletron"))
        {
            AddParticuleInPlace(particuleList, collision.gameObject.transform.position, eletron);
            Destroy(collision.gameObject);
        }
    }

    private void Start()
    {
        GetPositions();
    }

    /// <summary>
    /// Organiza a particuleList, para que se saiba onde cada particula deverá ficar.
    /// </summary>
    private void GetPositions()
    {
        Transform[] tempList = particuleFather.GetComponentsInChildren<Transform>();
        int contadorDeEspacos = 0;

        foreach (Transform trans in tempList)
        {
            if (trans.gameObject != particuleFather)
            {
                particulePositionTarget.Add(trans.position);
                Destroy(trans.gameObject);
                contadorDeEspacos++;
            }
        }
        particuleList = new GameObject[contadorDeEspacos];
    }

    /// <summary>
    /// Instancia a nova versão da partícula e a adiciona às duas listas de controle e chama as funções que permitirão com que ela se mova até o local especificado.
    /// </summary>
    /// <param name="vector">Vetor de GameObjects</param>
    /// <param name="startPosition">Posição onde será instaciada a partícula</param>
    /// <param name="particule">Qual tipo de particula</param>
    private void AddParticuleInPlace(GameObject[] vector, Vector3 startPosition, GameObject particule)
    {
        int nullSpace = FindNullSpace(vector);
        if (nullSpace != -1)
        {
            vector[nullSpace] = Instantiate(particule, startPosition, Quaternion.identity, particuleFather.transform);
            vector[nullSpace].GetComponent<Particule>().SetTargetPosition(particulePositionTarget[nullSpace]);
            vector[nullSpace].GetComponent<Particule>().SetIndex(nullSpace);
            construtorAtomo.AddParticula(particule.GetComponent<Eletron>().GetCarga(), particule.GetComponent<Eletron>().GetMassa());
        }
    }

    /// <summary>
    /// Deleta a partícula a partir do número de index dela.
    /// </summary>
    /// <param name="i"></param>
    public void DeletedParticule(int i)
    {
        construtorAtomo.RemoveParticula(particuleList[i].GetComponent<Eletron>().GetCarga(), particuleList[i].GetComponent<Eletron>().GetMassa());
        OrganizeParticule(particuleList, i);
    }

    private void OrganizeParticule(GameObject[] vector, int deletedParticule)
    {
        int lastParticule = FindLastMember(vector);
        if (lastParticule != -1)
        {
            vector[lastParticule].GetComponent<Particule>().SetTargetPosition(vector[deletedParticule].GetComponent<Particule>().GetTargetPosition());
            vector[lastParticule].GetComponent<Particule>().SetIndex(vector[deletedParticule].GetComponent<Particule>().GetIndex());
            vector[deletedParticule] = vector[lastParticule];
            vector[lastParticule] = null;
        }

    }

    /// <summary>
    /// Encontra o último membro (espaço não nulo) de um vetor
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    private int FindLastMember(GameObject[] vector)
    {
        for (int i = vector.Length - 1; i > 0; i--)
        {
            if (vector[i] != null)
            {
                return i;
            }
        }
        return -1;
    }

    /// <summary>
    /// Encontra o primeiro espaço nulo de um vetor
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    private int FindNullSpace(GameObject[] vector)
    {
        for (int i = 0; i < vector.Length; i++)
        {
            if (vector[i] == null)
            {
                return i;
            }
        }
        return -1;
    }
}
