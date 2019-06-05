using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlossaryItemsList", menuName = "My Assets/Glossary Items List")]
public class GlossaryItems : ScriptableObject
{
    public List<GlossaryElement> glossary;
}
