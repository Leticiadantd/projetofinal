using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MissaoBotoesCasa : MonoBehaviour
{
    [Header("Botões da UI")]
    public Button botaoBrilho;
    public Button botaoBinoculo;
    public Button botaoChave;
    public Button botaoPorta; // Opcional: se a porta for botão no Canvas

    [Header("Porta no Cenário (Opcional)")]
    [Tooltip("Se a porta for um objeto 2D na cena com Collider2D, arraste aqui.")]
    public GameObject portaNoCenario;

    [Header("Balão e Objetivo no Topo")]
    public GameObject painelBalao;
    public TextMeshProUGUI textoBalao;
    public TextMeshProUGUI textoObjetivoTopo;

    [Header("Textos da Missão")]
    [TextArea(2, 4)]
    public string falaBalao = "Tem algo brilhando... clique no binóculo para enxergar melhor.";
    public string objetivoPegarBinoculo = "Objetivo: clique no binóculo";
    public string objetivoPegarChave = "Objetivo: pegue a chave";
    public string objetivoSairDaCasa = "Objetivo: saia da casa";

    [Header("Tempo do Balão e Próxima Cena")]
    public float duracaoBalao = 3.5f;
    public bool fecharBalaoClicandoNele = true;
    public string nomeProximaCena = "cena2";

    [Header("Movimento do Jogador")]
    public MonoBehaviour scriptMovimentoJogador;

    private bool balaoAberto = false;
    private bool binoculoLiberado = false;
    private bool chaveLiberada = false;
    private Coroutine rotinaBalao;

    private void Start()
    {
        if (painelBalao != null) painelBalao.SetActive(false);
        if (textoObjetivoTopo != null) textoObjetivoTopo.gameObject.SetActive(false);

        if (botaoBrilho != null) botaoBrilho.gameObject.SetActive(true);
        if (botaoChave != null) botaoChave.gameObject.SetActive(false);

        if (botaoBrilho != null) botaoBrilho.onClick.AddListener(AoClicarNoBrilho);
        if (botaoBinoculo != null) botaoBinoculo.onClick.AddListener(AoClicarNoBinoculo);
        if (botaoChave != null) botaoChave.onClick.AddListener(AoClicarNaChave);
        if (botaoPorta != null) botaoPorta.onClick.AddListener(AoClicarNaPorta);
    }

    private void Update()
    {
        if (balaoAberto && fecharBalaoClicandoNele && Input.GetMouseButtonDown(0))
        {
            FecharBalao();
            return;
        }

        if (chaveLiberada && portaNoCenario != null && Input.GetMouseButtonDown(0))
        {
            VerificarCliqueNaPorta2D();
        }
    }

    private void VerificarCliqueNaPorta2D()
    {
        if (Camera.main == null) return;

        Vector3 posMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(posMundo, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == portaNoCenario)
        {
            AoClicarNaPorta();
        }
    }

    // 1. Jogador clica no botão do brilho
    public void AoClicarNoBrilho()
    {
        if (balaoAberto || binoculoLiberado) return;

        balaoAberto = true;
        DefinirMovimentoJogador(false);

        if (textoBalao != null) textoBalao.text = falaBalao;
        if (painelBalao != null) painelBalao.SetActive(true);

        if (rotinaBalao != null) StopCoroutine(rotinaBalao);
        if (duracaoBalao > 0f)
        {
            rotinaBalao = StartCoroutine(EsperarESumirBalao());
        }
    }

    private IEnumerator EsperarESumirBalao()
    {
        yield return new WaitForSeconds(duracaoBalao);
        FecharBalao();
    }

    public void FecharBalao()
    {
        if (!balaoAberto) return;

        balaoAberto = false;
        binoculoLiberado = true;

        if (rotinaBalao != null)
        {
            StopCoroutine(rotinaBalao);
            rotinaBalao = null;
        }

        if (painelBalao != null) painelBalao.SetActive(false);

        DefinirMovimentoJogador(true);

        if (textoObjetivoTopo != null)
        {
            textoObjetivoTopo.text = objetivoPegarBinoculo;
            textoObjetivoTopo.gameObject.SetActive(true);
        }
    }

    // 2. Jogador clica no binóculo -> binóculo some, brilho some e a chave assume o lugar dele
    public void AoClicarNoBinoculo()
    {
        if (!binoculoLiberado) return;

        if (botaoBinoculo != null) botaoBinoculo.gameObject.SetActive(false);
        if (botaoBrilho != null) botaoBrilho.gameObject.SetActive(false);
        if (botaoChave != null) botaoChave.gameObject.SetActive(true);

        if (textoObjetivoTopo != null)
        {
            textoObjetivoTopo.text = objetivoPegarChave;
            textoObjetivoTopo.gameObject.SetActive(true);
        }
    }

    // 3. Jogador clica na chave -> chave some e libera a saída pela porta
    public void AoClicarNaChave()
    {
        if (botaoChave != null) botaoChave.gameObject.SetActive(false);

        chaveLiberada = true;

        if (textoObjetivoTopo != null)
        {
            textoObjetivoTopo.text = objetivoSairDaCasa;
            textoObjetivoTopo.gameObject.SetActive(true);
        }
    }

    // 4. Jogador clica na porta após pegar a chave -> troca de cena
    public void AoClicarNaPorta()
    {
        if (!chaveLiberada) return;

        if (!string.IsNullOrWhiteSpace(nomeProximaCena))
        {
            SceneManager.LoadScene(nomeProximaCena);
        }
    }

    private void DefinirMovimentoJogador(bool permitir)
    {
        if (scriptMovimentoJogador == null) return;

        var campo = scriptMovimentoJogador.GetType().GetField("podeMover");
        if (campo != null && campo.FieldType == typeof(bool))
        {
            campo.SetValue(scriptMovimentoJogador, permitir);
        }
        else
        {
            scriptMovimentoJogador.enabled = permitir;
        }
    }
}