using UnityEngine;

public class DialogueWatcher : MonoBehaviour
{
    [Header("Arraste aqui o Painel/Caixa de Diálogo da UI")]
    public GameObject dialoguePanel; 
    
    private bool dialogueWasOpen = false;
    private bool objectiveTriggered = false;

    void Update()
    {
        if (objectiveTriggered || dialoguePanel == null) return;

        // Detecta que o diálogo abriu
        if (dialoguePanel.activeInHierarchy)
        {
            dialogueWasOpen = true;
        }
        // Se estava aberto e agora fechou, ativa o objetivo
        else if (dialogueWasOpen && !dialoguePanel.activeInHierarchy)
        {
            objectiveTriggered = true;
            QuestManager.Instance.StartObjective();
        }
    }
}