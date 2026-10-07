using UnityEngine;

public class osvaldo : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float velocidade = 3f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 direcao = new Vector2(horizontal, vertical).normalized;
        float velocidadeAnimacao = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

        if (animator != null)
        {
            animator.SetFloat("VELOCIDADE", velocidadeAnimacao);
            animator.speed = velocidadeAnimacao > 0.01f ? 1f : 0f;
        }

        if (spriteRenderer != null)
        {
            if (horizontal < 0f)
            {
                spriteRenderer.flipX = true;
            }
            else if (horizontal > 0f)
            {
                spriteRenderer.flipX = false;
            }
        }

        if (rb != null)
        {
            rb.velocity = direcao * velocidade;
        }
    }
}
