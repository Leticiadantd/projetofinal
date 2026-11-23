using UnityEngine;

public class MalaInteraction : MonoBehaviour
{
    [Header("Configurações")]
    public float interactionRange = 3f;
    public Transform jogador; // Arraste o personagem (Osvaldo) aqui no Inspector

    [Header("Visual da Mala")]
    public Sprite spriteMalaAberta; // Opcional: arraste a imagem da mala aberta aqui
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

        // 2. Verifica se o objetivo da mala realmente está ativo antes de abrir
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

        // Muda o sprite da mala para aberta (se tiver configurado)
        if (spriteRenderer != null && spriteMalaAberta != null)
        {
            spriteRenderer.sprite = spriteMalaAberta;
        }

        // Conclui o objetivo no seu GerenciadorDeObjetivos
        if (GerenciadorDeObjetivos.Instance != null)
        {
            GerenciadorDeObjetivos.Instance.ConcluirObjetivoMala();
        }

        Debug.Log("Mala aberta! Você pegou o dinheiro.");
    }
}