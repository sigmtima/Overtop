using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor.Analytics;

namespace _Project.Scripts
{
    public class GameRestart : MonoBehaviour
    {
        public void OnEnable()
        {
            StartCoroutine(StartGameRestart());
        }

        private IEnumerator StartGameRestart()
        {
            yield return new WaitForSeconds(7f);
            FullGameRestart();
        }
        public void FullGameRestart()
        {
            Time.timeScale = 1f;

            GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            foreach (GameObject obj in allObjects)
            {
                if (obj.transform.parent == null && obj != gameObject)
                {
                    Destroy(obj);
                }
            }

            SceneManager.LoadScene(0);
        }
    }
}