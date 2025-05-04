using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance { get; private set; }

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        StartCoroutine(FadeOut());
    }
    public void FadeInFadeOut()
    {
        StartCoroutine(FadeIn());
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeIn()
    {
        float time = 0;
        Color color = fadeImage.color;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            color.a = time / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }
        color.a = 1;
        fadeImage.color = color;       
    }
    IEnumerator FadeOut()
    {
        float time = fadeDuration;
        Color color = fadeImage.color;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            color.a = time / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }
        color.a = 0f;
        fadeImage.color = color;
    }
}
