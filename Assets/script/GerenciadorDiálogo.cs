using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciadorDialogo : MonoBehaviour
{
    public static GerenciadorDialogo Instance;

    [Header("Componentes de UI")]
    public GameObject painelDialogo;
    public TextMeshProUGUI textoNome;
    public TextMeshProUGUI textoFala;

    private Queue<LinhaDialogo> filasDialogo = new Queue<LinhaDialogo>();
    private bool dialogoAtivo = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Update()
    {
        if (dialogoAtivo && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            ProximaFala();
        }
    }

    public void IniciarDialogo(List<LinhaDialogo> conversas)
    {
        filasDialogo.Clear();

        foreach (LinhaDialogo linha in conversas)
        {
            filasDialogo.Enqueue(linha);
        }

        dialogoAtivo = true;
        if (painelDialogo != null) painelDialogo.SetActive(true);

        ProximaFala();
    }

    public void ProximaFala()
    {
        if (filasDialogo.Count == 0)
        {
            EncerrarDialogo();
            return;
        }

        LinhaDialogo linhaAtual = filasDialogo.Dequeue();
        if (textoNome != null) textoNome.text = linhaAtual.nomePersonagem;
        if (textoFala != null) textoFala.text = linhaAtual.textoFala;
    }

    private void EncerrarDialogo()
    {
        dialogoAtivo = false;
        if (painelDialogo != null) painelDialogo.SetActive(false);

        if (GerenciadorDeObjetivos.Instance != null)
        {
            GerenciadorDeObjetivos.Instance.AtivarObjetivoPiecks();
        }
    }
}