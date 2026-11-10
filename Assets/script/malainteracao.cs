
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
            dinheiroVisual.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (malaAberta)
            return;

        if (GerenciadorDeObjetivos.Instance == null)
            return;

        if (!GerenciadorDeObjetivos.Instance.ObjetivoMalaAtivo)
        {
            Debug.Log("Voce ainda nao pode abrir a mala!");
            return;
        }

        AbrirMala();
    }

    private void AbrirMala()
    {
        malaAberta = true;

        if (spriteMala != null && spriteMalaAberta != null)
            spriteMala.sprite = spriteMalaAberta;

        if (dinheiroVisual != null)
            dinheiroVisual.SetActive(true);

        GerenciadorDeObjetivos.Instance.ConcluirObjetivoMala();

        Debug.Log("Dinheiro encontrado!");
    }
}
