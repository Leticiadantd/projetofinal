using UnityEngine;
using UnityEngine.SceneManagement;

public class BarcoInteracao : MonoBehaviour
{
    [Header("Configuração")]
    public string nomeProximaCena = "cena 3 (dentro do barco)"; 
    public GameObject avisoTexto; 

    private bool jogadorPorPerto = false;

    void Start()
    {
        if (avisoTexto != null)
        {
            avisoTexto.SetActive(false);
        }
    }

    void Update()
    {
        // Se estiver perto e carregar na tecla 'E'
        if (jogadorPorPerto && Input.GetKeyDown(KeyCode.E))
        {
            EntrarNoBarco();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto que bateu tem a Tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorPorPerto = true;
            Debug.Log("O cãozinho encostou fisicamente ao barco! Pressiona 'E'.");

            if (avisoTexto != null)
            {
                avisoTexto.SetActive(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorPorPerto = false;
            Debug.Log("O cãozinho afastou-se do barco.");

            if (avisoTexto != null)
            {
                avisoTexto.SetActive(false);
            }
        }
    }

    void EntrarNoBarco()
    {
        Debug.Log("A entrar na cena: " + nomeProximaCena);
        SceneManager.LoadScene(nomeProximaCena);
    }
}