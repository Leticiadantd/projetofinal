using UnityEngine;

public class TrocaSala : MonoBehaviour
{
    [Header("Painéis de Fundo")]
    public GameObject painelAtual;
    public GameObject painelDestino;

    [Header("Ponto de Destino do Jogador")]
    public Transform pontoDeSaida;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.gameObject.name == "OSV1")
        {
            // Ativa o próximo painel e desativa o atual
            painelDestino.SetActive(true);
            painelAtual.SetActive(false);

            // Teleporta o jogador para o outro lado da sala
            collision.transform.position = pontoDeSaida.position;
        }
    }
}