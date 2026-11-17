using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("UI")]
    public TextMeshProUGUI objectiveText;

    [Header("Estado do Objetivo")]
    public string currentObjective = "Objetivo: Encontre o dinheiro na mala";
    public bool isObjectiveCompleted = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        if (objectiveText != null)
        {
            objectiveText.gameObject.SetActive(false);
        }
    }

    public void StartObjective()
    {
        if (objectiveText != null)
        {
        // objectiveText.gameObject.SetActive(true);
            UpdateUI();
        }
    }

    public void CompleteObjective()
    {
        if (!isObjectiveCompleted)
        {
            isObjectiveCompleted = true;
            currentObjective = "Objetivo Concluído: Dinheiro encontrado!";
            UpdateUI();
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