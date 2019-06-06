using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Classe básica para armazenar as informações de um elemento do glossário
/// </summary>
[System.Serializable]
public class GlossaryElement
{
    public string expression;
    public VideoClip expressionVideo;
    public string meaning;
    public VideoClip meaningVideo;
}
