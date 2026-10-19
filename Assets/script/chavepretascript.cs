using UnityEngine;

public class chavepretascript : MonoBehaviour
{
    [Header("Seguir o Cachorro")]
    public Transform cachorro; // Arrasta o cãozinho para aqui no Inspector
    private bool foiColetada = false;

    [Header("Texto / Mensagem")]
    public GameObject textoDica; // Arrasta o texto de aviso para aqui

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
        }
    }
}