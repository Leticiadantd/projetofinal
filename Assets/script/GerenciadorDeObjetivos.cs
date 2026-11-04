using UnityEngine;
using TMPro;

public class GerenciadorDeObjetivos : MonoBehaviour
{
    public static GerenciadorDeObjetivos Instance;

    [Header("Interface UI")]
    public TextMeshProUGUI textoObjetivo;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AtivarObjetivoPiecks()
    {
        AtualizarTextoObjetivo("Objetivo: Pague o bilheteiro usando Piecks.");
    }

    public void AtivarObjetivoBarco()
    {
        AtualizarTextoObjetivo("Objetivo: Encontrar a chave para abrir o barco");
    }

    public void AtualizarTextoObjetivo(string novoTexto)
    {
        if (textoObjetivo != null)
        {
            textoObjetivo.text = novoTexto;
        }
    }
}