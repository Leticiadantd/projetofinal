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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que encostou tem a Tag "Player"
        if (collision.CompareTag("Player"))
        {
            jogadorPorPerto = true;
            Debug.Log("O cãozinho chegou perto do barco! Pressiona 'E'.");

            if (avisoTexto != null)
            {
                avisoTexto.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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