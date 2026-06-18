using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private float fadeDuration = 1f;

    public void OnScreenChange()
    {
        deathScreen.SetActive(true);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0;

        float timer = 0;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;

            canvasGroup.alpha = timer / fadeDuration;

            yield return null;
        }

        canvasGroup.alpha = 1;
    }
    public void ExitToMenu()
    {
        Debug.Log("Exiting Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}