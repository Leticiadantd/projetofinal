using UnityEngine;

public class PassosCachorro : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Som do Passo")]
    public AudioClip somDoPasso;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    // Podes chamar esta função publicamente sempre que o cão der um passo
    public void TocarSomDoPasso()
    {
        if (somDoPasso != null && audioSource != null)
        {
            audioSource.PlayOneShot(somDoPasso);
        }
    }
}