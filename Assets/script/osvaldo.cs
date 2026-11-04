using UnityEngine;

public class osvaldo : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float velocidade = 3f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");

        
        float velocidadeAnimacao = Mathf.Abs(horizontal);
        if (animator != null)
        {
            animator.SetFloat("VELOCIDADE", velocidadeAnimacao);
            animator.speed = velocidadeAnimacao > 0.01f ? 1f : 0f;
        }
        
        
        if (horizontal > 0)
            spriteRenderer.flipX = false;
        else if (horizontal < 0)
            spriteRenderer.flipX = true;
    }

    private void FixedUpdate()
    {
        
        if (rb != null)
        {
            rb.velocity = new Vector2(horizontal * velocidade, rb.velocity.y);
        }
    }
}