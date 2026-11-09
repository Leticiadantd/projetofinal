using UnityEngine;
using TMPro;

public class GerenciadorDeObjetivos : MonoBehaviour
{
    public static GerenciadorDeObjetivos Instance;

    [Header("Interface UI")]
    public TextMeshProUGUI textoObjetivo;

    private void Awake()
    {
        // Garante que só existe um GerenciadorDeObjetivos na cena
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AtivarObjetivoPiecks()
    {
        AtualizarTextoObjetivo("Objetivo: Pague o bilheteiro usando Piecks.");
    }

    public void AtivarObjetivoBarco()
    {
        AtualizarTextoObjetivo("Objetivo: Encontrar a chave para abrir o barco.");
    }

    // Método genérico para atualizar o texto do objetivo livremente
    public void AtualizarTextoObjetivo(string novoTexto)
    {
        if (textoObjetivo != null)
        {
            textoObjetivo.text = novoTexto;
        }
        else
        {
            Debug.LogWarning("O campo 'Texto Objetivo' não está atribuído no Inspector!");
        }
    }
}