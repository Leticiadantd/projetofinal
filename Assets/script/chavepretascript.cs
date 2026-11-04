using UnityEngine;

public class chavepretascript : MonoBehaviour
{
    [Header("Seguir o Cachorro")]
    public Transform cachorro; 
    private bool foiColetada = false;

    [Header("Texto / Mensagem")]
    public GameObject textoDica; 

    void Start()
    {
        if (textoDica != null)
        {
            textoDica.SetActive(false);
        }
    }

    void Update()
    {
        if (foiColetada && cachorro != null)
        {
            transform.position = cachorro.position + new Vector3(0f, 1.2f, 0f);
        }
    }

    void OnMouseEnter()
    {
        if (!foiColetada && textoDica != null)
        {
            textoDica.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (textoDica != null)
        {
            textoDica.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (!foiColetada)
        {
            foiColetada = true;

            if (textoDica != null)
            {
                textoDica.SetActive(false);
            }

            if (GerenciadorDeObjetivos.Instance != null)
            {
                GerenciadorDeObjetivos.Instance.AtualizarTextoObjetivo("Objetivo: Entre no barco.");

             
            }
        }
    }
}
