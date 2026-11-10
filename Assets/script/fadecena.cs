
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCena : MonoBehaviour
{
    [Header("Configuracao")]
    public CanvasGroup painelFade;
    public float duracaoFade = 2f;

    private bool transicaoAtiva = false;

    private void Start()
    {
        // Verifica se veio da cena anterior
        if (PlayerPrefs.GetInt("FadeAoEntrar", 0) == 1)
        {
            PlayerPrefs.SetInt("FadeAoEntrar", 0);

            painelFade.alpha = 1f;
            StartCoroutine(FadeIn());
        }
        else
        {
            painelFade.alpha = 0f;
        }
    }

    // Chame este metodo para ir para a Cena 4
    public void IrParaCena4()
    {
        if (!transicaoAtiva)
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        transicaoAtiva = true;

        float tempo = 0f;

        while (tempo < duracaoFade)
        {
            tempo += Time.deltaTime;

            painelFade.alpha = Mathf.Clamp01(
                tempo / duracaoFade
            );

            yield return null;
        }

        painelFade.alpha = 1f;

        // Avisa a proxima cena que deve clarear
        PlayerPrefs.SetInt("FadeAoEntrar", 1);

        // Carrega a Cena 4
        SceneManager.LoadScene("cena4");
    }

    private IEnumerator FadeIn()
    {
        float tempo = 0f;

        while (tempo < duracaoFade)
        {
            tempo += Time.deltaTime;

            painelFade.alpha = 1f - Mathf.Clamp01(
                tempo / duracaoFade
            );

            yield return null;
        }

        painelFade.alpha = 0f;
    }
}
