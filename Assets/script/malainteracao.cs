
using UnityEngine;

public class MalaInteracao : MonoBehaviour
{
    [Header("Aparencia da Mala")]
    public SpriteRenderer spriteMala;

    public Sprite spriteMalaAberta;

    [Header("Dinheiro")]
    public GameObject dinheiroVisual;

    private bool malaAberta = false;

    private void Start()
    {
        if (dinheiroVisual != null)
        {
            dinheiroVisual.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (malaAberta)
            return;

        if (GerenciadorDeObjetivos.Instance == null)
            return;

        // So permite abrir quando o objetivo estiver ativo
        if (!GerenciadorDeObjetivos.Instance.ObjetivoMalaAtivo)
        {
            Debug.Log("Ainda nao e hora de abrir a mala!");
            return;
        }

        AbrirMala();
    }

    private void AbrirMala()
    {
        malaAberta = true;

        // Troca a imagem da mala
        if (spriteMala != null && spriteMalaAberta != null)
        {
            spriteMala.sprite = spriteMalaAberta;
        }

        // Mostra o dinheiro
        if (dinheiroVisual != null)
        {
            dinheiroVisual.SetActive(true);
        }

        // Conclui a missao
        GerenciadorDeObjetivos.Instance.ConcluirObjetivoMala();

        Debug.Log("Dinheiro encontrado! Missao concluida!");
    }
}
