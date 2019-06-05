using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlossaryManager : MonoBehaviour
{
    public GlossaryItems glossaryList;

    public GameObject glossaryPrefab;
    public GameObject glossaryWindow;
    private List<GameObject> glossaryItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < glossaryList.glossary.Count; i++)
        {
            GameObject temp = Instantiate(glossaryPrefab, glossaryWindow.transform);
            temp.GetComponent<GlossaryPrefabSelfManager>().UpdatePrefabs(glossaryList.glossary[i]);
            glossaryItems.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
