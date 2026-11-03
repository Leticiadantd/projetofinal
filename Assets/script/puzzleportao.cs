using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlePortao : MonoBehaviour
{
    [Header("Configuração da Sequência")]
    [Tooltip("Ordem correta das cores das pedras preciosas (ex: Vermelho, Azul, Amarelo, Vermelho)")]
    public List<string> sequenciaCorreta = new List<string> { "Vermelho", "Azul", "Amarelo", "Vermelho" };

    [Header("Estado Atual")]
    private List<string> sequenciaIntroduzida = new List<string>();

    [Header("Eventos")]
    public UnityEvent aoResolverPuzzle;
    public UnityEvent aoErrarSequencia;

    /// <summary>
    /// Método a ser chamado pelo botão/interação da pedra preciosa.
    /// Passa o nome da cor como parâmetro (ex: "Vermelho").
    /// </summary>
    public void PressionarPedra(string cor)
    {
        sequenciaIntroduzida.Add(cor);
        Debug.Log($"Pedra pressionada: {cor}");

        // Verifica a entrada atual até ao momento
        int indiceAtual = sequenciaIntroduzida.Count - 1;

        if (sequenciaIntroduzida[indiceAtual] != sequenciaCorreta[indiceAtual])
        {
            Debug.Log("Sequência incorreta! Reiniciando...");
            sequenciaIntroduzida.Clear();
            aoErrarSequencia?.Invoke();
            return;
        }

        // Se a sequência completa estiver correta
        if (sequenciaIntroduzida.Count == sequenciaCorreta.Count)
        {
            Debug.Log("Puzzle Resolvido! O portão abre-se.");
            aoResolverPuzzle?.Invoke();
        }
    }
}