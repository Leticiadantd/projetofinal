
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCena : MonoBehaviour
{
    [Header("Painel de Transicao")]
    public CanvasGroup painelFade;

    [Header("Configuracoes")]
    public float duracaoFade = 2f;
    public float tempoEspera = 5f;

    [Header("Transicao Automatica")]
    public bool transicaoAutomatica = true;
    public string nomeProximaCena = "cena4";

    private bool transicaoAtiva = false;

    private void Awake()
{
    if (painelFade == null)
    {
        painelFade = GetComponent<CanvasGroup>();
    }

    // Se ainda nao existir, cria automaticamente
    if (painelFade == null)
    {
        painelFade = gameObject.AddComponent<CanvasGroup>();

        Debug.Log("Canvas Group criado automaticamente!");
    }
}

    private void Start()
    {
        if (painelFade == null)
        {
            Debug.LogError("Nao encontrei o Canvas Group! Adicione Canvas Group ao PainelFade.");
            return;
        }

        StartCoroutine(PrepararTransicao());
    }

    private IEnumerator PrepararTransicao()
    {
        if (PlayerPrefs.GetInt("FadeAoEntrar", 0) == 1)
        {
            PlayerPrefs.SetInt("FadeAoEntrar", 0);

            painelFade.alpha = 1f;

            yield return StartCoroutine(FadeIn());
        }
        else
        {
            painelFade.alpha = 0f;
        }

        if (transicaoAutomatica)
        {
            Debug.Log("Aguardando transicao...");

            yield return new WaitForSeconds(tempoEspera);

            yield return StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        if (transicaoAtiva)
            yield break;

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

        if (!Application.CanStreamedLevelBeLoaded(nomeProximaCena))
        {
            Debug.LogError("Cena nao encontrada: " + nomeProximaCena);
            transicaoAtiva = false;
            yield break;
        }

        PlayerPrefs.SetInt("FadeAoEntrar", 1);

        SceneManager.LoadScene(nomeProximaCena);
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
