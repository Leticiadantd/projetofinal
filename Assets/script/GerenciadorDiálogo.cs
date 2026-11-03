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

    [Header("Posições dos Balões no Canvas")]
    [Tooltip("Posição perto da Coruja (Bilheteiro)")]
    public Vector2 posicaoBilheteiro = new Vector2(-200, 100);

    [Tooltip("Posição perto do Cachorro (Otávio)")]
    public Vector2 posicaoOtavio = new Vector2(250, -50);

    private Queue<LinhaDialogo> filasDialogo = new Queue<LinhaDialogo>();
    private bool dialogoAtivo = false;
    private RectTransform rectPainel;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        if (painelDialogo != null)
        {
            rectPainel = painelDialogo.GetComponent<RectTransform>();
        }
    }

    private void Start()
    {
        // Esconde o painel assim que o jogo começa
        if (painelDialogo != null)
        {
            painelDialogo.SetActive(false);
        }
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

        // Mostra o balão só quando a conversa começa
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

        // Alterna a posição do balão de acordo com quem está a falar
        if (rectPainel != null)
        {
            if (linhaAtual.nomePersonagem.ToLower().Contains("otávio") || linhaAtual.nomePersonagem.ToLower().Contains("otavio"))
            {
                rectPainel.anchoredPosition = posicaoOtavio;
            }
            else
            {
                rectPainel.anchoredPosition = posicaoBilheteiro;
            }
        }
    }

    private void EncerrarDialogo()
    {
        dialogoAtivo = false;

        // Esconde o balão ao terminar o diálogo
        if (painelDialogo != null) painelDialogo.SetActive(false);

        if (GerenciadorDeObjetivos.Instance != null)
        {
            GerenciadorDeObjetivos.Instance.AtivarObjetivoPiecks();
        }
    }
}