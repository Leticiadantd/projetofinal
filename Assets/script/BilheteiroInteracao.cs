using System.Collections.Generic;
using UnityEngine;

public class BilheteiroInteracao : MonoBehaviour
{
    [Header("Falas da Cena")]
    public List<LinhaDialogo> dialogoInicial = new List<LinhaDialogo>();

    private bool jaInteragiu = false;

    private void Start()
    {
        // Preenche o diálogo com as falas do seu roteiro
        if (dialogoInicial.Count == 0)
        {
            dialogoInicial.Add(new LinhaDialogo { nomePersonagem = "Otávio", textoFala = "Com licença, meu bom senhor, preciso ir ao Oriente!" });
            dialogoInicial.Add(new LinhaDialogo { nomePersonagem = "Bilheteiro", textoFala = "Cadê o seu bilhete?" });
            dialogoInicial.Add(new LinhaDialogo { nomePersonagem = "Otávio", textoFala = "Eu não tenho, mas posso pagar! Quantas moedas de ouro são necessárias?" });
            dialogoInicial.Add(new LinhaDialogo { nomePersonagem = "Bilheteiro", textoFala = "Só aceitamos Piecks." });
            dialogoInicial.Add(new LinhaDialogo { nomePersonagem = "Otávio", textoFala = "...Olhe..." });
        }
    }

    // Clique Point and Click sobre o Bilheteiro
    private void OnMouseDown()
    {
        if (!jaInteragiu)
        {
            jaInteragiu = true;
            GerenciadorDialogo.Instance.IniciarDialogo(dialogoInicial);
        }
    }
}