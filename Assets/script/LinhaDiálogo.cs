
using System;
using UnityEngine;

[Serializable]
public class LinhaDialogo
{
    public string nomePersonagem;

    [TextArea(2, 5)]
    public string textoFala;
}
