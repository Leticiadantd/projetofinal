
using UnityEngine;
using TMPro;

public class GerenciadorDeObjetivos : MonoBehaviour
{
    public static GerenciadorDeObjetivos Instance;

    [Header("Interface")]
    public TextMeshProUGUI textoObjetivo;

    public bool ObjetivoMalaAtivo { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void AtivarObjetivoMala()
    {
        ObjetivoMalaAtivo = true;

        AtualizarTextoObjetivo(
            "OBJETIVO: Abra a mala e encontre o dinheiro!"
        );
    }

    public void ConcluirObjetivoMala()
    {
        if (!ObjetivoMalaAtivo)
            return;

        ObjetivoMalaAtivo = false;

        AtualizarTextoObjetivo(
            "MISSÃO CONCLUÍDA: Dinheiro encontrado!"
        );
    }

    public void AtivarObjetivoPiecks()
    {
        ObjetivoMalaAtivo = false;

        AtualizarTextoObjetivo(
            "Objetivo: Pague o bilheteiro usando Piecks."
        );
    }

    public void AtivarObjetivoBarco()
    {
        ObjetivoMalaAtivo = false;

        AtualizarTextoObjetivo(
            "Objetivo: Encontrar a chave para abrir o barco."
        );
    }

    public void AtualizarTextoObjetivo(string novoTexto)
    {
        if (textoObjetivo != null)
            textoObjetivo.text = novoTexto;
        else
            Debug.LogWarning("TextoObjetivo nao foi atribuido!");
    }
}
