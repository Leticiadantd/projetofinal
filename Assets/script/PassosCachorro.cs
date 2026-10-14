using UnityEngine;

public class Osvaldo : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip somDoPasso; // Arrastas o som para aqui no Inspector

    [Header("Controle de Passos")]
    public float tempoEntrePassos = 0.3f; // Velocidade em que os passos se repetem
    private float contadorPassos;

    void Start()
    {
        // Pega ou cria o AudioSource automaticamente
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // Verifica se estás a apertar as setas do teclado (esquerda/direita/horizontal) ou W/A/S/D
        float movimentoHorizontal = Input.GetAxisRaw("Horizontal");

        if (movimentoHorizontal != 0)
        {
            contadorPassos += Time.deltaTime;

            // Se passou o tempo do passo, toca o som e reinicia o contador
            if (contadorPassos >= tempoEntrePassos)
            {
                if (somDoPasso != null)
                {
                    audioSource.PlayOneShot(somDoPasso);
                }
                contadorPassos = 0f;
            }
        }
        else
        {
            // Se o cão parar de andar (soltares as setas), reseta o contador
            contadorPassos = tempoEntrePassos; // Assim toca imediatamente no primeiro passo quando voltares a andar
        }
    }
}