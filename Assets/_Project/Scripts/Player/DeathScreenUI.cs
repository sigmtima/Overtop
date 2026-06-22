using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class DeathScreenUI : MonoBehaviour
    {
        [SerializeField] private GameObject deathScreen;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private int mainMenuIndex;

        [SerializeField] private float fadeDuration = 1f;

        public void ShowDeathScreen()
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
            SceneManager.LoadScene(mainMenuIndex);
        }
    }
}