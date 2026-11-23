using UnityEngine;

public class MalaInteraction : MonoBehaviour
{
    [Header("Configurações")]
    public float interactionRange = 3f;
    public Transform jogador; 

    [Header("Visual da Mala")]
    public Sprite spriteMalaAberta; 
    private SpriteRenderer spriteRenderer;

    private bool opened = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (opened) return;

        if (jogador != null)
        {
            float distancia = Vector2.Distance(transform.position, jogador.position);
            if (distancia > interactionRange)
            {
                Debug.Log("Muito longe da mala! Chegue mais perto.");
                return;
            }
        }

        if (GerenciadorDeObjetivos.Instance != null &&
            GerenciadorDeObjetivos.Instance.ObjetivoMalaAtivo)
        {
            AbrirMala();
        }
        else
        {
            Debug.Log("Você não precisa abrir a mala agora.");
        }
    }

    private void AbrirMala()
    {
        opened = true;

        if (spriteRenderer != null && spriteMalaAberta != null)
        {
            spriteRenderer.sprite = spriteMalaAberta;
        }

        if (GerenciadorDeObjetivos.Instance != null)
        {
            GerenciadorDeObjetivos.Instance.ConcluirObjetivoMala();
        }

        Debug.Log("Mala aberta! Você pegou o dinheiro.");
    }
}