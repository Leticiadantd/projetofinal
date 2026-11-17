using UnityEngine;
using TMPro; // Use TextMeshPro para o texto na tela

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("UI")]
    public TextMeshProUGUI objectiveText; // Arraste o texto da UI aqui

    [Header("Estado do Objetivo")]
    public string currentObjective = "Objetivo: Encontre o dinheiro na mala";
    public bool isObjectiveCompleted = false;

    private void Awake()
    {
        // Padrão Singleton para facilitar o acesso de outros scripts
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    // Método chamado quando o jogador interage com a mala
    public void CompleteObjective()
    {
        if (!isObjectiveCompleted)
        {
            isObjectiveCompleted = true;
            currentObjective = "Objetivo Concluído: Dinheiro encontrado!";
            UpdateUI();
            
            // Aqui você pode adicionar lógica extra (tocar som, abrir painel, etc.)
            Debug.Log("Missão cumprida!");
        }
    }

    void UpdateUI()
    {
        if (objectiveText != null)
        {
            objectiveText.text = currentObjective;
        }
    }
}