using UnityEngine;

public class ChaveItem : MonoBehaviour
{
    [Header("Configuração de Flutuação")]
    public float velocidadeFlutuacao = 3f;
    public float alturaFlutuacao = 0.25f;
    private Vector3 posicaoInicial;

    [Header("Seguir o Cachorro")]
    public Transform cachorro; // Arrasta o cãozinho (OSV1) para aqui no Inspector
    private bool foiColetada = false;

    [Header("Texto / Mensagem")]
    public GameObject textoDica; // Arrasta o texto de aviso para aqui

    void Start()
    {
        posicaoInicial = transform.position;

        // Garante que a mensagem começa escondida
        if (textoDica != null)
        {
            textoDica.SetActive(false);
        }
    }

    void Update()
    {
        if (!foiColetada)
        {
            // Efeito de flutuar suavemente para cima e para baixo (estilo Minecraft)
            float novaAltura = posicaoInicial.y + Mathf.Sin(Time.time * velocidadeFlutuacao) * alturaFlutuacao;
            transform.position = new Vector3(transform.position.x, novaAltura, transform.position.z);
        }
        else if (cachorro != null)
        {
            // Se foi coletada, acompanha a posição do cachorro (um bocadinho acima dele)
            transform.position = cachorro.position + new Vector3(0f, 1.2f, 0f);
        }
    }

    // Executado automaticamente quando o rato passa por cima da chave
    void OnMouseEnter()
    {
        if (!foiColetada && textoDica != null)
        {
            textoDica.SetActive(true);
        }
    }

    // Executado quando o rato sai de cima da chave
    void OnMouseExit()
    {
        if (textoDica != null)
        {
            textoDica.SetActive(false);
        }
    }

    // Executado quando o jogador clica em cima da chave com o rato
    void OnMouseDown()
    {
        if (!foiColetada)
        {
            foiColetada = true;

            // Esconde o texto de dica ao apanhar
            if (textoDica != null)
            {
                textoDica.SetActive(false);
            }
        }
    }
}