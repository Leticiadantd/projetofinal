using UnityEngine;

public class DinheiroInterativo : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Conclui o objetivo no seu GerenciadorDeObjetivos
        if (GerenciadorDeObjetivos.Instance != null)
        {
            GerenciadorDeObjetivos.Instance.ConcluirObjetivoMala();
        }

        Debug.Log("Dinheiro coletado!");

        // Faz o dinheiro sumir da mala após ser pego
        gameObject.SetActive(false);
    }
}