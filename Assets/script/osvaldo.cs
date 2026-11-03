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

        
        if (rb != null)
        {
            rb.velocity = new Vector2(horizontal * velocidade, rb.velocity.y);
        }

        
        float velocidadeAnimacao = Mathf.Abs(horizontal);
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
    }
}