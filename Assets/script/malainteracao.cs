using UnityEngine;

public class MalaInteraction : MonoBehaviour
{
    [Header("Configurações")]
    public float interactionRange = 3f; // Distância de interação (se for por proximidade/clique)
    private bool opened = false;

    // Se você estiver usando cliques do mouse 2D (OnMouseDown do Unity):
    private void OnMouseDown()
    {
        if (!opened)
        {
            opened = true;
            
            // Avisa o Gerenciador de Objetivos que a mala foi aberta/encontrada
            if (QuestManager.Instance != null)
            {
                QuestManager.Instance.CompleteObjective();
            }

            // Exemplo: mudar o sprite da mala para aberta, se tiver
            // GetComponent<SpriteRenderer>().sprite = spriteMalaAberta;
        }
    }
}