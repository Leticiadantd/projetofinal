using UnityEngine;

public class osvaldo : MonoBehaviour
{
    [Header("Movimento")]
    [SerializeField] private float velocidade = 3f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direcao = new Vector3(horizontal, vertical, 0f).normalized;
        transform.position += direcao * velocidade * Time.deltaTime;

        float velocidadeAnimacao = Mathf.Abs(horizontal) + Mathf.Abs(vertical);

        if (animator != null)
        {
            animator.SetFloat("VELOCIDADE", velocidadeAnimacao);
            animator.speed = velocidadeAnimacao > 0.01f ? 1f : 0f;
        }
    }
}
