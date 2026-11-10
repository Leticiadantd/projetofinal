
using System.Collections.Generic;
using UnityEngine;

public class BilheteiroInteracao : MonoBehaviour
{
    public List<LinhaDialogo> dialogoInicial =
        new List<LinhaDialogo>();

    private bool jaInteragiu = false;

    private void Start()
    {
        if (dialogoInicial.Count == 0)
        {
            dialogoInicial.Add(new LinhaDialogo
            {
                nomePersonagem = "Otávio",
                textoFala = "Com licença, meu bom senhor, preciso ir ao Oriente!"
            });

            dialogoInicial.Add(new LinhaDialogo
            {
                nomePersonagem = "Bilheteiro",
                textoFala = "Cadê o seu bilhete?"
            });

            dialogoInicial.Add(new LinhaDialogo
            {
                nomePersonagem = "Otávio",
                textoFala = "Eu não tenho, mas posso pagar! Quantas moedas de ouro são necessárias?"
            });

            dialogoInicial.Add(new LinhaDialogo
            {
                nomePersonagem = "Bilheteiro",
                textoFala = "Só aceitamos Piecks."
            });

            dialogoInicial.Add(new LinhaDialogo
            {
                nomePersonagem = "Otávio",
                textoFala = "...Olhe..."
            });
        }
    }

    private void OnMouseDown()
    {
        if (jaInteragiu)
            return;

        if (GerenciadorDialogo.Instance == null)
            return;

        jaInteragiu = true;

        GerenciadorDialogo.Instance.IniciarDialogo(
            dialogoInicial,
            AoTerminarDialogo
        );
    }

    private void AoTerminarDialogo()
    {
        if (GerenciadorDeObjetivos.Instance != null)
        {
            GerenciadorDeObjetivos.Instance.AtivarObjetivoMala();
        }
    }
}
