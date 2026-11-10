
using System;
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

    [Header("Posicoes dos Baloes no Canvas")]
    [Tooltip("Posicao perto da Coruja (Bilheteiro)")]
    public Vector2 posicaoBilheteiro = new Vector2(-200, 100);

    [Tooltip("Posicao perto do Cachorro (Otavio)")]
    public Vector2 posicaoOtavio = new Vector2(250, -50);

    private Queue<LinhaDialogo> filasDialogo = new Queue<LinhaDialogo>();

    private bool dialogoAtivo = false;

    private RectTransform rectPainel;
    private RectTransform canvasRect;

    // NOVO: Acao executada quando o dialogo terminar
    private Action aoTerminarDialogo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (painelDialogo != null)
        {
            rectPainel = painelDialogo.GetComponent<RectTransform>();

            Canvas parentCanvas = painelDialogo.GetComponentInParent<Canvas>();

            if (parentCanvas != null)
            {
                canvasRect = parentCanvas.GetComponent<RectTransform>();
            }
        }
    }

    private void Start()
    {
        if (painelDialogo != null)
        {
            painelDialogo.SetActive(false);
        }
    }

    private void Update()
    {
        if (dialogoAtivo &&
            (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            ProximaFala();
        }
    }

    // ALTERADO: Agora aceita uma acao ao terminar o dialogo
    public void IniciarDialogo(
        List<LinhaDialogo> conversas,
        Action callback = null)
    {
        if (dialogoAtivo) return;

        filasDialogo.Clear();

        foreach (LinhaDialogo linha in conversas)
        {
            filasDialogo.Enqueue(linha);
        }

        aoTerminarDialogo = callback;

        dialogoAtivo = true;

        // Mostra o balao quando a conversa comeca
        if (painelDialogo != null)
            painelDialogo.SetActive(true);

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

        if (textoNome != null)
            textoNome.text = linhaAtual.nomePersonagem;

        if (textoFala != null)
            textoFala.text = linhaAtual.textoFala;

        if (rectPainel != null)
        {
            Vector2 posicaoAlvo = posicaoBilheteiro;

            if (linhaAtual.nomePersonagem.ToLower().Contains("otavio") ||
                linhaAtual.nomePersonagem.ToLower().Contains("otávio"))
            {
                posicaoAlvo = posicaoOtavio;
            }

            PosicionarEManterNaTela(posicaoAlvo);
        }
    }

    private void PosicionarEManterNaTela(Vector2 posicaoDesejada)
    {
        rectPainel.anchoredPosition = posicaoDesejada;

        if (canvasRect == null) return;

        Vector2 tamanhoPainel = rectPainel.rect.size;
        Vector2 pivot = rectPainel.pivot;

        float limiteMinX = (-canvasRect.rect.width * 0.5f)
                           + (tamanhoPainel.x * pivot.x);

        float limiteMaxX = (canvasRect.rect.width * 0.5f)
                           - (tamanhoPainel.x * (1f - pivot.x));

        float limiteMinY = (-canvasRect.rect.height * 0.5f)
                           + (tamanhoPainel.y * pivot.y);

        float limiteMaxY = (canvasRect.rect.height * 0.5f)
                           - (tamanhoPainel.y * (1f - pivot.y));

        float xClamped = Mathf.Clamp(
            posicaoDesejada.x, limiteMinX, limiteMaxX);

        float yClamped = Mathf.Clamp(
            posicaoDesejada.y, limiteMinY, limiteMaxY);

        rectPainel.anchoredPosition = new Vector2(
            xClamped, yClamped);
    }

    // ALTERADO: Finaliza o dialogo e executa a acao recebida
    private void EncerrarDialogo()
    {
        dialogoAtivo = false;

        if (painelDialogo != null)
            painelDialogo.SetActive(false);

        Action callback = aoTerminarDialogo;
        aoTerminarDialogo = null;

        if (callback != null)
        {
            callback.Invoke();
        }
        else if (GerenciadorDeObjetivos.Instance != null)
        {
            // Mantem o comportamento antigo quando nao existe callback
            GerenciadorDeObjetivos.Instance.AtivarObjetivoPiecks();
        }
    }
}
